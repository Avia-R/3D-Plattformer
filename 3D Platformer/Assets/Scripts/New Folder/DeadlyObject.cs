using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scenemanagement;
using UnityEngine;

public class DeadlyObject : MonoBehaviour
{
    
    void OnColliSionEnter(Collision col)
    {
        if (col.gameobject.tag == "Player")
        {
            int numlife = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getLifes();
            if (numlife > 0)
            {

                numlife = numlife - 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().OnDeath();

            }
            else
            {
            
            }

        }
        
        
    }
}
