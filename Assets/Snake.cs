using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    List<Transform> segments;

    public Transform segmentPrefab;
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
            direction = Vector2.right;
        else if (Input.GetAxisRaw("Horizontal") == -1)
            direction = Vector2.left;
        else if (Input.GetAxisRaw("Vertical") == 1)
            direction = Vector2.up;
        else if (Input.GetAxisRaw("Vertical") == -1)
            direction= Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Food")
        {
            Grow();
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        transform.position = new Vector3(direction.x + transform.position.x, direction.y + transform.position.y, 0);
    }

    void Grow()
    {
        Vector3 lastElemPos = segments[segments.Count - 1].transform.position;
        Transform segment = Instantiate(segmentPrefab);
        segment.position = lastElemPos;
        segments.Add(segment);
    }
}
