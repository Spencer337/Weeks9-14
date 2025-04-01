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
    public float laserTime = 5;
    public int bulletsFired;
    //public int bulletNumber = 0;
    public Vector3 startingPos;
    public UnityEvent onSpace;
    public GameObject bulletPrefab;
    public List<GameObject> bullets;
    public GameObject laser;
    public AsteroidSpawner spawner;
    void Start()
    {
        startingPos = transform.position;
        onSpace.AddListener(FireBullet);
        bullets = new List<GameObject>();
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
        if (bulletsFired == 3)
        {
            onSpace.RemoveListener(FireBullet);
            onSpace.AddListener(ActivateLaser);
            bulletsFired = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpace.Invoke();
            onSpace.RemoveListener(ActivateLaser);
        }
        if (bullets.Count > 0)
        {
            CheckCollision();
        }
        RemoveBullet();
    }

    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;

        Bullet b = newBullet.GetComponent<Bullet>();
        bullets.Add(newBullet);
        bulletsFired++;
    }

    public void ActivateLaser()
    {
        StartCoroutine(FireLaser());
    }

    public void CheckCollision()
    {
        for (int j = bullets.Count - 1; j >= 0; j--)
        {
            for (int i = spawner.asteroids.Count - 1; i >= 0; i--)
            {
                float distance = Vector3.Distance(spawner.asteroids[i].transform.position, bullets[j].transform.position);
                if (distance <= 1)
                {
                    Destroy(spawner.asteroids[i]);
                    spawner.asteroids.RemoveAt(i);
                    Destroy(bullets[j]);
                    bullets.RemoveAt(j);
                    Debug.Log("Colliding");
                }
            }
        }
    }

    public void RemoveBullet()
    {
        for (int j = bullets.Count - 1; j >= 0; j--)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(bullets[j].transform.position);
            if (screenPos.x > Screen.width)
            {
                Debug.Log("should be deleted");
                Destroy(bullets[j]);
                bullets.RemoveAt(j);
            }
        }
    }

    IEnumerator FireLaser()
    {
        t = 0;
        laser.SetActive(true);
        while (t < laserTime)
        {
            t += Time.deltaTime;

            yield return null;
        }
        laser.SetActive(false);
        onSpace.AddListener(FireBullet);
    }

    public void DeleteBullet(GameObject a)
    {
        bullets.Remove(a);
    }
}
