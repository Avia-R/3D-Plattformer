using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
  private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(gameObject.transform.position, name:"deathzone");
    }
}
