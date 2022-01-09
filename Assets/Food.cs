using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    
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
        int spawnX = (int)Random.Range(gridArea.bounds.min.x, gridArea.bounds.max.x);
        int spawnY = (int)Random.Range(gridArea.bounds.min.y, gridArea.bounds.max.y);
        transform.position = new Vector3(spawnX, spawnY, 0);
    }
}
