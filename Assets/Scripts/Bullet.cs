using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    public AsteroidSpawner spawner;
    public float speed = 2;
    //public Coroutine MoveBullet;

    void Start()
    {
        StartCoroutine(MoveBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveBullet()
    {
        while (true)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            //for (int i = spawner.howManyAsteroids - 1; i >= 0; i--)
            //{
            //    float distance = Vector3.Distance(spawner.asteroids[i].transform.position, transform.position);
            //    if (distance <= 1)
            //    {
            //        Debug.Log("Colliding");
            //    }
            //}
            Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);
            if (screenPos.x > Screen.width)
            {
                Bullet.Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
}
