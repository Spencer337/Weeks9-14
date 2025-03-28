using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapper : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile grass;
    public Tile stone;

    public CinemachineImpulseSource impulseSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPos = tilemap.WorldToCell(mousePos);

            Debug.Log(gridPos);

            if (tilemap.GetTile(gridPos) == stone)
            {
                Debug.Log("This is stone, turn into grass");
                tilemap.SetTile(gridPos, grass);
                //impulseSource.GenerateImpulse();
            }
            else
            {
                Debug.Log("This is grass, turn into stone");
                tilemap.SetTile(gridPos, stone);
                impulseSource.GenerateImpulse();
            }
        }
    }
}
