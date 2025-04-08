using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float t;
    public int bulletsFired;
    public Vector3 startingPos;
    public UnityEvent onSpace;
    public UnityEvent onScore;
    public GameObject bulletPrefab;
    public List<GameObject> bullets;
    public GameObject laser;
    public AsteroidSpawner spawner;
    public ScoreManager score;
    void Start()
    {
        // Set the position the player is reset to
        startingPos = transform.position;
        // Add the update score function to the onScore event
        onScore.AddListener(score.UpdateScore);
        // Add the fire bullet function to the onSpace event
        onSpace.AddListener(FireBullet);
        // Create a life of bullets
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player up and down if the up and down keys are pressed
        transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        // Calculate the screen position of the player
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // If the player is off the screen, bring them back to the starting position
        if (screenPos.y < 0 ||  screenPos.y > Screen.height)
        {
            transform.position = startingPos;
        }

        // If the number of bullets fired equals 10, remove the fire bullet function and add the activate laser function
        // Also, set bullets fired back to zero
        if (bulletsFired == 10)
        {
            onSpace.RemoveListener(FireBullet);
            onSpace.AddListener(ActivateLaser);
            bulletsFired = 0;
        }

        // If the space key is pressed, invoke the onSpace event, and remove the activate laser listener
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpace.Invoke();
            onSpace.RemoveListener(ActivateLaser);
            
        }

        // If there is at least one bullet, check for collision between bullets and asteroids
        if (bullets.Count > 0)
        {
            CheckCollision();
        }
        RemoveBullet();
    }

    // Create a new bullet and set it to the player's position
    // Add the bullet to a list of bullets
    // Increase the number of bullets fired by one 
    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;

        Bullet b = newBullet.GetComponent<Bullet>();
        bullets.Add(newBullet);
        bulletsFired++;
    }

    // Start the fire laser coroutine
    public void ActivateLaser()
    {
        StartCoroutine(FireLaser());
    }

    // Go though the lists of bullets and asteroids
    public void CheckCollision()
    {
        for (int j = bullets.Count - 1; j >= 0; j--)
        {
            for (int i = spawner.asteroids.Count - 1; i >= 0; i--)
            {
                // Compare the distance of each bullet to the distance of each asteroid
                float distance = Vector3.Distance(spawner.asteroids[i].transform.position, bullets[j].transform.position);
                
                // If they are close enough to be touching, remove the bullet from it's list and the asteroid from it's list
                if (distance <= 1)
                {
                    Destroy(spawner.asteroids[i]);
                    spawner.asteroids.RemoveAt(i);
                    Destroy(bullets[j]);
                    bullets.RemoveAt(j);
                    // Increase the score
                    onScore.Invoke();
                    
                }
            }
        }
    }

    // Go though the entire life of bullets, if any of them are offscreen, delete them and remove the from the list
    public void RemoveBullet()
    {
        for (int j = bullets.Count - 1; j >= 0; j--)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(bullets[j].transform.position);
            if (screenPos.x > Screen.width)
            {
                Destroy(bullets[j]);
                bullets.RemoveAt(j);
            }
        }
    }

    IEnumerator FireLaser()
    {
        t = 0;
        // Set the laser object to be active
        laser.SetActive(true);
        // Count up for three seconds
        while (t < 3)
        {
            t += Time.deltaTime;

            yield return null;
        }

        // After the three seconds are done, deactivate the laser and add the fire bullet function back to the onSpace listener
        laser.SetActive(false);
        onSpace.AddListener(FireBullet);
    }
}
