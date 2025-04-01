using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int howManyAsteroids = 0;
    public List<GameObject> asteroids;
    public float t = 0;
    public float interval = 3;
    // Start is called before the first frame update
    void Start()
    {
        asteroids = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= interval)
        {
            GameObject newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.transform.position = new Vector3(7.5f, Random.Range(-5, 5), 0);

            Asteroid a = newAsteroid.GetComponent<Asteroid>();
            a.spawner = this;

            asteroids.Add(newAsteroid);
            howManyAsteroids++;
            t = 0;
        }
    }

    public void AsteroidHit(GameObject a)
    {
        asteroids.Remove(a);
    }
}
