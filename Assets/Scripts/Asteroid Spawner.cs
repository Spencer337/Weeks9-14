using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public List<GameObject> asteroids;
    public float t = 0;
    public float interval = 3;
    
    void Start()
    {
        // Create a new list of asteroids
        asteroids = new List<GameObject>();
        
    }

    
    void Update()
    {
        t += Time.deltaTime;
        // Every three seconds, spawn a new asteroid at the right side of the screen, with a random y value
        // Add the asteroid to a list of asteroids
        if (t >= interval)
        {
            GameObject newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.transform.position = new Vector3(7.5f, Random.Range(-5, 5), 0);

            Asteroid a = newAsteroid.GetComponent<Asteroid>();
            a.spawner = this;

            asteroids.Add(newAsteroid);
            t = 0;
        }
    }

    public void AsteroidHit(GameObject a)
    {
        asteroids.Remove(a);
    }
}
