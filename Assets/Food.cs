using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private Bounds _bounds;
    void Start()
    {
        Spawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Snake")
            Spawn();
    }
    void Spawn()
    {
        bool isSpawnable = true;
        _bounds = gridArea.bounds;
        int spawnX = (int)Random.Range(_bounds.min.x, _bounds.max.x);
        int spawnY = (int)Random.Range(_bounds.min.y, _bounds.max.y);
        foreach (Transform segment in Snake.Segments)
        {
            if (spawnX == segment.position.x && spawnY == segment.position.y)
            {
                isSpawnable = false;
                break;
            }
        }
        if (isSpawnable)
            transform.position = new Vector3(spawnX, spawnY, 0);
        else
        {
            Spawn();
        }
    }
}
