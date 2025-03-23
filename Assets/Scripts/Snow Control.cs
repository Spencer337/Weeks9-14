using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControl : MonoBehaviour
{
    public ParticleSystem snow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snow.gameObject.SetActive(!snow.gameObject.activeInHierarchy);
        }

        if (Input.GetMouseButton(0))
        {
            if (snow.isPlaying == true)
            {
                snow.Stop();
            }
            else 
            {
                snow.Play();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            snow.Emit(10);
        }
    }
}
