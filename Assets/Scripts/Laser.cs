using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Laser : MonoBehaviour
{
    public GameObject player;
    public AsteroidSpawner spawner;
    public UnityEvent onScore;
    public ScoreManager score;

    void Start()
    {
        // Add the update score method to the onScore event
        onScore.AddListener(score.UpdateScore);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the laser's position to be slightly to the right of the player
        Vector3 pos = player.transform.position;
        pos.x = 1;
        transform.position = pos;

        // Get the laser's position as if the laser's x value was 0
        Vector3 laserTempPos = transform.position;
        laserTempPos.x = 0;

        // Go through the entire list of asteroids, and if they collide with the laser, remove them and increase the score
        for (int i = spawner.asteroids.Count - 1; i >= 0; i--)
        {
            //Get the asteroid's position as if it's x value was 0
            Vector3 asteroidTempPos = spawner.asteroids[i].transform.position;
            asteroidTempPos.x = 0;

            // Find the distance between the laser and asteroid if their x values are zero
            float distance = Vector3.Distance(asteroidTempPos, laserTempPos);
            if (distance <= 1)
            {
                Destroy(spawner.asteroids[i]);
                spawner.asteroids.RemoveAt(i);
                onScore.Invoke();
            }
        }


    }

}
