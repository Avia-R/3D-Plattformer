using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      Spawn();
    }

    public void Test(){

    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
    	    if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y +(Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        
    }

    public void OnDeath(){
        Spawn();
    }

    void JumpOnEnemy(float bumpSpeed){
        //controller.velocity = new Vector3(controller.velocity.x, y:bumpSpeed, controller.velocity.z);
    }

    public void Spawn()
    {
        transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathZone"))
    {
        Spawn();
    }
    
    }

    private void OnCollisonEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            Collider col = other.gameObject.GetComponent<Collider>();
            Collider myCol = this.gameObject.GetComponent<Collider>();


            if(enemy.invincible){
                OnDeath();
            }
            else if(myCol.bounds.center.y - myCol.bounds.extents.y > 
            col.bounds.center.y + 0.5f * col.bounds.extents.y){
                JumpOnEnemy(enemy.bumpSpeed);
                enemy.OnDeath();
            }else{
                OnDeath();
            }
        }
    }
}
