using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalSquare : MonoBehaviour
{
    public float t;

    public void Grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
        }
    }
}
