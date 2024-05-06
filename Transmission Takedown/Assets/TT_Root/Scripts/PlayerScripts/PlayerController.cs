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

    [Header("Movement Stats")]
    public float speed;
    public float carSpeed;
    public float rotSpeed;
    float turnSpeed;



    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 360;
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotation();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        input = new Vector3(move.x, 0, move.y);
    }

    void Move()
    {                                                  
        playerRb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    void Rotation()
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    
    

}
