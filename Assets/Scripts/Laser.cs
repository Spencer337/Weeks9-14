using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject player;
    //public float t;
    //public float laserTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.x = 1;
        transform.position = pos;
    }

    //IEnumerator ManageLaser()
    //{
    //    while(t < laserTime)
    //    {
    //        yield return null;  
    //    }
    //} 
}
