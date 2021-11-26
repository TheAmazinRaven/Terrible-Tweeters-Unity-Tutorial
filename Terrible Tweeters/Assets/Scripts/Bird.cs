using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // saving starting position
        _startPosition = _rigidbody2D.position;
        // will not move due to physics in unity but bc of the code
        _rigidbody2D().isKinematic = true;
    }
    
    // color red when clicked
    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }
    
    // change color to white when un-clicked
    void OnMouseUp()
    {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * -500);

        _spriteRenderer.color = Color.white;
    }
    
    // Behavior for when we drag the birdie, will move bird to that position
    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
