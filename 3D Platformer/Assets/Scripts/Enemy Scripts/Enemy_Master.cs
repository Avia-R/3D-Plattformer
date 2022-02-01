using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Master : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject sword;
    [SerializeField] private float Distance;
    [SerializeField] private bool isAngered;
    [SerializeField] private NavMeshAgent agent;

    private float health = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if(Distance <= 200)
        {
            isAngered = true;
        }
        else if(Distance >= 200f)
        {
            isAngered = false;
        }

        if(isAngered)
        {
            agent.isStopped = false;
            agent.SetDestination(Player.transform.position);
        }
        else if(!isAngered)
        {
            agent.isStopped = true;
        }
    }
    private void OnTriggerEnter(Collider other)
{
    if(other.gameObject == Player)
    {
        GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setHealth(-2);
    }
    if(other.gameObject == sword)
    {
        health -= GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getAttackDamage();
        if(health <= 0)
        {
            Destroy(this);
        }
    }
}
}
