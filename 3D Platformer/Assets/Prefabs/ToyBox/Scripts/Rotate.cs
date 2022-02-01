using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public GameObject Player;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * speed * 10);
	}

	private void OnTriggerEnter(Collider other)
{
    if(other.gameObject == Player)
    {
        Player.transform.parent = transform;
    }
}

private void OnTriggerExit(Collider other)
{
   if(other.gameObject == Player)
    {
        Player.transform.parent = null;
    }
}
}
