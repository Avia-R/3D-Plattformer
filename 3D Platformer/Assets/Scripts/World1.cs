using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World1 : MonoBehaviour
{
    public GameObject Player;
    private bool isOn;
    // Start is called before the first frame update
    private void Update() 
    {
        if(isOn)
        {
            if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("World 1 Level 1");
        }
        }
    }


    // Update is called once per frame
private void OnTriggerEnter(Collider other)
{
    if(other.gameObject == Player)
    {
        Player.transform.parent = transform;
        isOn = true;
        GameObject.FindGameObjectWithTag("World1").GetComponent<MoveHintY>().setOffset((float)0.1);
    }
}
private void OnTriggerExit(Collider other)
{
   if(other.gameObject == Player)
    {
        Player.transform.parent = null;
        isOn = false;
        GameObject.FindGameObjectWithTag("World1").GetComponent<MoveHintY>().setOffset((float)0.03);
    }
}

}
