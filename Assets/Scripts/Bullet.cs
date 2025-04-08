using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    public AsteroidSpawner spawner;
    public PlayerController player;
    public float speed = 2;
    public bool isDead = false;

    void Start()
    {
        // Start the coroutine to move the bullet
        StartCoroutine(MoveBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Keep the bullet moving to the right at a constant speed
    IEnumerator MoveBullet()
    {
        while (true)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            yield return null;
        }
    }
}
