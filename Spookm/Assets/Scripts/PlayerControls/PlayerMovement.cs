using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkingSpeed;
    public float runningSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    float moveSpeed;

    Vector3 moveDirection;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //grounded check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        setMovementSpeed();
        SpeedControl();

        //    if (grounded)
        //    {
        //        if (isMoving())
        //        {
        //            Debug.Log("Moving");
        //            rb.drag = groundDrag;
        //        }
        //        else
        //        {
        //            Debug.Log("Not moving");
        //            rb.drag = 100;
        //        }

        //    } else
        //    {
        //        Debug.Log("Not grounded");
        //        rb.drag = 0;
        //    }
        //}
        if (isMoving())
        {
            Debug.Log("Moving");
            rb.drag = groundDrag;
        }
        else
        {
            Debug.Log("Not moving");
            rb.drag = 20;
        }

    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private bool isMoving()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            return true;
        }
        return false;
    }

    private void setMovementSpeed()
    {
        if (Input.GetKey("left shift"))
        {
            moveSpeed = runningSpeed;
        } else
        {
            moveSpeed = walkingSpeed;
        }
    }
}
