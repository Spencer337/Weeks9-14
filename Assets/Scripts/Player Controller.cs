using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float t;
    public float laserTime = 5;
    public int bulletNumber;
    public Vector3 startingPos;
    public UnityEvent onSpace;
    public GameObject bulletPrefab;
    public GameObject laser;
    void Start()
    {
        startingPos = transform.position;
        onSpace.AddListener(FireBullet);
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
        if (bulletNumber == 20)
        {
            onSpace.RemoveListener(FireBullet);
            onSpace.AddListener(ActivateLaser);
            bulletNumber = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpace.Invoke();
            onSpace.RemoveListener(ActivateLaser);
        }
    }

    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        bulletNumber++;
    }

    public void ActivateLaser()
    {
        StartCoroutine(FireLaser());
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
}
