using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TooClose : MonoBehaviour
{

    private Transform player;
    
    private float dist;
    public float moveSpeed;
    public Transform point;
    public float howClose;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(player.position, transform.position);


        if(dist <= howClose)
        {
            transform.LookAt(point);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

        }
    }

}
