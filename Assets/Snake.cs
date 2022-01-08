using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    void Start()
    {
        
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

    private void FixedUpdate()
    {
        transform.position = new Vector3(direction.x + transform.position.x, direction.y + transform.position.y, 0);
    }
}
