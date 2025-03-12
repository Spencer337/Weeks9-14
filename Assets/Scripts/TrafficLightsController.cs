using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightsController : MonoBehaviour
{
    public UnityEvent OnRightClick;
    public UnityEvent OnLeftClick;

    private void Update()
    {
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClick.Invoke();
        }

        // Right Click
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick.Invoke();
        }
    }

    public void StopTraffic()
    {
        Debug.Log("Stop");
    }

    public void GoTraffic()
    {
        Debug.Log("Go");
    }
}
