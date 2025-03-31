using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
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
