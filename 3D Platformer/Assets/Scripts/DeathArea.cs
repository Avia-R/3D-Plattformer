using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
  public GameObject Player;
  private void OnTriggerEnter(Collider other)
{
    if(other.gameObject == Player)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().OnDeath();
    }
}
  private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(gameObject.transform.position, name:"deathzone");
    }
}
