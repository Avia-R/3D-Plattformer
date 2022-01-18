using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private Vector3 moveDirection;
    private CharacterController controller;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    private Vector3 velocity;
    [SerializeField] private float gravity;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move() 
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        Debug.Log(isGrounded);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);

        if(isGrounded)
        {
                if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();

            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;

            if(Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {

    }

    private void Walk()
    {
        Debug.Log("Walk!");
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        Debug.Log("Run!");
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        Debug.Log("Jump!");
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
