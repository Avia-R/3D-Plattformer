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
    private Vector3 velocity;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [SerializeField] private float rotationSpeed;

    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Move() 
    {

        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection.Normalize();

                if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();

            }
            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }

        if(controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
        }
        
        moveDirection *= moveSpeed;
        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

    }
}
