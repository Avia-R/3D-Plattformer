using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
public GameObject Player;
  private void OnTriggerEnter(Collider other)
{
    if(other.gameObject == Player)
    {
        GameObject.FindWithTag("SpawnPoint").transform.position = transform.position;
    }
}
private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(gameObject.transform.position, name:"checkpointt");
    }
}
