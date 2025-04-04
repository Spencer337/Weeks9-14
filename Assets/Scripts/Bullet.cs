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
    //public Vector2 screenPos = Vector2.zero;

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
            yield return null;
        }
    }

    public void deleteSelf()
    {
        Destroy(gameObject);
    }
}
