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
    [SerializeField] bool insta;
    float turnSpeed;    
    [SerializeField] float sensitivity;
    private float currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 360;
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        normalSpeed = speed;
        canMove = true;
        insta = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (insta) { move = playerInput.actions["Movement"].ReadValue<Vector2>(); }
        input = new Vector3(move.x, 0, move.y);
        Rotation();
        Debug.Log(move);
        if (input == new Vector3(0, 0, 0) && !dashing) { playerAnimator.SetBool("Run", false); }
        
        if (WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.car) { speed = carSpeed; }
        else { speed = normalSpeed; }
        FirstTime();
    }

    private void FixedUpdate()
    {
        if (canMove) { Move(); }
        
        
    }

    

    void Move()
    {   
        
        playerRb.velocity = input * speed;
        playerAnimator.SetBool("Run", true);
    }

    void Rotation()
    {
        if (move.sqrMagnitude == 0) return;


        var targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, sensitivity);
        transform.rotation = Quaternion.Euler(0, angle, 0);



        if (input != Vector3.zero)
        {
            /*
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
            

            //transform.Rotate(Vector3.up * move.x * sensitivity);
            
            */

            


        }
    }


    void FirstTime()
    {
        if (WeaponManager.Instance.firstSword == true && WeaponManager.Instance.canSword == true)
        {
            WeaponManager.Instance.firstSword = false;
            playerAnimator.SetTrigger("TakeSword");
            StopMove();
        }
        if (WeaponManager.Instance.firstGun == true && WeaponManager.Instance.canGun == true && WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.gun)
        {
            
            WeaponManager.Instance.firstGun = false;
            playerAnimator.SetTrigger("NewWeapon");
            StopMove();
        }
        if (WeaponManager.Instance.firstBomber == true && WeaponManager.Instance.canBomber == true && WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.bomber)
        {
            WeaponManager.Instance.firstBomber = false;
            
            playerAnimator.SetTrigger("NewWeapon");
            StopMove();
        }
        if (WeaponManager.Instance.firstBigArm == true && WeaponManager.Instance.canArm == true && WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.bigarm)
        {
            WeaponManager.Instance.firstBigArm = false;
            playerAnimator.SetTrigger("NewWeapon");
            StopMove();
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

    void ResetInput()
    {
        insta = true;
    }

    void OnDash()
    {
        dashing = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.car)
        {
            playerRb.AddForce(-transform.forward * speed);
            insta = false;
            Invoke(nameof(ResetInput), 0.2f);
            
        }
    }
}
