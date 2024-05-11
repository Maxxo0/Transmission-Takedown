using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    PlayerInput playerInput;
    Vector2 move;
    Vector3 input;
    Rigidbody playerRb;
    Animator playerAnimator;

    [Header("Movement Stats")]
    public float speed;
    public float normalSpeed;
    public float carSpeed;
    public float rotSpeed;
    [SerializeField] float dashCD;
    [SerializeField] float dashForce;
    [SerializeField] bool canMove;
    [SerializeField] bool canDash;
    [SerializeField] bool dashing;
    float turnSpeed;    
    [SerializeField] float sensitivity;



    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 360;
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        normalSpeed = speed;
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotation();
        Debug.Log(move);
        if (input == new Vector3(0, 0, 0) && !dashing) { playerAnimator.SetBool("Run", false); }
        
        if (WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.car) { speed = carSpeed; }
        else { speed = normalSpeed; }

    }

    private void FixedUpdate()
    {
        if (canMove) { Move(); }
        
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        input = new Vector3(move.x, 0, move.y);
    }

    void Move()
    {   
        
        playerRb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
        playerAnimator.SetBool("Run", true);
    }

    void Rotation()
    {
        if (input != Vector3.zero)
        {
            /*
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
            

            //transform.Rotate(Vector3.up * move.x * sensitivity);
            
            */

            var targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);


        }
    }

    public void StopMove()
    {
        canMove = false;
        Invoke(nameof(ResetSpeed), 0.3f);
    }

    void ResetSpeed()
    {
        canMove = true;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && canDash) 
        {
            canDash = false;
            dashing = true;
            playerRb.AddForce(transform.forward * dashForce);
            playerAnimator.SetBool("Run", true);
            Invoke(nameof(OnDash), 0.5f);
            Invoke(nameof(ResetDash), dashCD);
        }
        if (context.canceled)
        {
            
        }
    }

    void ResetDash()
    {
       
        canDash = true;
    }

    void OnDash()
    {
        dashing = false;
    }
    
}
