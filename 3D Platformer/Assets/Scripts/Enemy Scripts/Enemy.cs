using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Rigidbody enemyRigidbody;

    public bool invincible;
    public float bumpSpeed = 10f;
    private void Awake()
    {
        enemyRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        enemyRigidbody.velocity = new Vector3(x:speed, enemyRigidbody.velocity.y, z:0);
    }

    public void OnDeath()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("End"))
        {
            speed*=-1;
        }
    }
}
