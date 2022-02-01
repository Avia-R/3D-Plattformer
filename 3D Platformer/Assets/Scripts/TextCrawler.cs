using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCrawler : MonoBehaviour
{
    public float scrollSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        Vector3 pso = transform.position;
        Vector3 loacalVectorUp = transform.TransformDirection(0,1,0);

        pso += loacalVectorUp*scrollSpeed*Time.deltaTime;
        transform.position = pso;
    }
}
