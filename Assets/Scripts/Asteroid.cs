using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = -1;
    float t;
    public int health = 1;
    public AsteroidSpawner spawner;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // Move to the left at a consistent speed
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // If the asteroid's x value is less than -5.5, delete the asteroid 
        if (transform.position.x < -5.5)
        {
            spawner.AsteroidHit(gameObject);
            Destroy(gameObject);
        }
    }
}
