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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (transform.position.x < -5.5)
        {
            spawner.AsteroidHit(gameObject);
            Destroy(gameObject);
        }
    }

    public void deleteSelf()
    {
        Destroy(gameObject);
    }
}
