using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    Vector2 currentDirection;
    List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    const int initSize = 4;
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && currentDirection != Vector2.left)
        {
            direction = Vector2.right;
            currentDirection = direction;
        }
            
        else if (Input.GetAxisRaw("Horizontal") == -1 && currentDirection != Vector2.right)
        {    
            direction = Vector2.left;
            currentDirection = direction;
        }
           
        else if (Input.GetAxisRaw("Vertical") == 1 && currentDirection != Vector2.down)
        {
            direction = Vector2.up;
            currentDirection = direction;
        }

        else if (Input.GetAxisRaw("Vertical") == -1 && currentDirection != Vector2.up)
        {
            direction = Vector2.down;
            currentDirection = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Food")
            Grow();
        else if (collision.tag == "Obstacle")
            GameOver();
    }

    private void FixedUpdate()
    {
        //Snake movement
        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position; 
        transform.position = new Vector3(direction.x + transform.position.x, direction.y + transform.position.y, 0);
    }

    void Grow()
    {
        Vector3 lastElemPos = segments[segments.Count - 1].transform.position;
        Transform segment = Instantiate(segmentPrefab);
        segment.position = lastElemPos;
        segments.Add(segment);
    }

    void GameOver()
    {
        for (int i = 1; i < segments.Count; i++)
            Destroy(segments[i].gameObject);
        segments.Clear();
        transform.position = new Vector3(0, 0, 0);
        Reset();
    }

    void Reset()
    {
        segments.Add(transform);
        for (int i = 1; i < initSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
        direction = Vector3.left;
    }
}
