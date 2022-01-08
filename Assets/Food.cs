using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    
    void Start()
    {
        float spawnX = Random.Range(gridArea.bounds.min.x, gridArea.bounds.max.x);
        float spawnY = Random.Range(gridArea.bounds.min.y, gridArea.bounds.max.y);
        transform.position = new Vector3(spawnX, spawnY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
