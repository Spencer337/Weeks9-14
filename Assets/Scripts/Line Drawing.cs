using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> ListOfPoints;

    private void Start()
    {
        ListOfPoints = new List<Vector2>();
        lr.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ListOfPoints.Add(newPosition);

            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, newPosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ListOfPoints = new List<Vector2>();
            lr.positionCount = 0;
        }
    }
}