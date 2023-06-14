using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float groundDrag = 5.0f;
    [SerializeField]
    private float speedModifier = 4.0f;

    [SerializeField]
    private float playerHeight = 2.0f;
    [SerializeField]
    private float halfValue = 0.5f;
    [SerializeField]
    private float extraDistance = 0.2f;

    [SerializeField]
    private float jumpPower = 7.0f;
    [SerializeField]
    private float jumpModifier = 0.1f;

    public Transform orientation;
    public LayerMask whatIsGround;

    private float horizontalInput, verticalInput;

    private bool grounded = true;
    

    Vector3 moveDirection;

    //[SerializeField]
    //private int updateCount, fixedUpdateCount;

    private float xMove, zMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * halfValue + extraDistance, whatIsGround);

        MyInput();
        SpeedControl();
 
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        //Get the input values from the player
        //xMove = Input.GetAxis("Horizontal") * speed;
        //zMove = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }
    
    private void MovePlayer()
    {
        moveDirection = new Vector3 (orientation.forward.x, 0, orientation.forward.z).normalized * verticalInput + orientation.right * horizontalInput;

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * speedModifier, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * speedModifier * jumpModifier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {

        //Limits velocity of the rigidbody to speed.

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump ()
    {
        // Reset Y velocity.

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }
}
