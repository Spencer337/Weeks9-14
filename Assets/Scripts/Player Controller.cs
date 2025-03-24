using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float t;
    public float laserTime;
    public int bulletNumber;
    public Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        

        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        if (screenPos.y > 0 && screenPos.y < Screen.height)
        {
            transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = startingPos;
        }
    }
}
