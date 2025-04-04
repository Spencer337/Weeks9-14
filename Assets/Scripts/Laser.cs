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
        onScore.AddListener(score.UpdateScore);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.x = 1;
        transform.position = pos;
        Vector3 laserTempPos = transform.position;
        laserTempPos.x = 0;
        for (int i = spawner.asteroids.Count - 1; i >= 0; i--)
        {
            Vector3 asteroidTempPos = spawner.asteroids[i].transform.position;
            asteroidTempPos.x = 0;
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
