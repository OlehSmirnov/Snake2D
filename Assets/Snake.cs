using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    private Vector2 _currentDirection;
    public static readonly List<Transform> Segments = new List<Transform>();
    public Transform segmentPrefab;
    private const int InitSize = 4;
    public Text score;
    private int counter;
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && _currentDirection != Vector2.left)
        {
            _direction = Vector2.right;
            _currentDirection = _direction;
        }
            
        else if (Input.GetAxisRaw("Horizontal") == -1 && _currentDirection != Vector2.right)
        {    
            _direction = Vector2.left;
            _currentDirection = _direction;
        }
           
        else if (Input.GetAxisRaw("Vertical") == 1 && _currentDirection != Vector2.down)
        {
            _direction = Vector2.up;
            _currentDirection = _direction;
        }

        else if (Input.GetAxisRaw("Vertical") == -1 && _currentDirection != Vector2.up)
        {
            _direction = Vector2.down;
            _currentDirection = _direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Food")
        {
            Grow();
        }
        else if (collision.CompareTag("Obstacle"))
            GameOver();
    }

    private void FixedUpdate()
    {
        //Snake movement
        for (int i = Segments.Count - 1; i > 0; i--)
            Segments[i].position = Segments[i - 1].position;
        var position = transform.position;
        position = new Vector3(_direction.x + position.x, _direction.y + position.y, 0);
        transform.position = position;
    }

    private void Grow()
    {
        var segment = Instantiate(segmentPrefab);
        segment.position = Segments[Segments.Count - 1].transform.position;
        Segments.Add(segment);
        GetComponent<AudioSource>().Play();
        counter++;
        score.text = counter.ToString();
    }

    private void GameOver()
    {
        for (int i = 1; i < Segments.Count; i++)
            Destroy(Segments[i].gameObject);
        Segments.Clear();
        transform.position = Vector3.zero;
        Reset();
    }

    private void Reset()
    {
        Segments.Add(transform);
        for (int i = 1; i < InitSize; i++)
            Segments.Add(Instantiate(segmentPrefab));
        _direction = Vector3.left;
        counter = 0;
        score.text = counter.ToString();
    }
}