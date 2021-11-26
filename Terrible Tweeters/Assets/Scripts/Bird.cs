using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 _startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // saving starting position
        _startPosition = GetComponent<Rigidbody2D>().position;
        // will not move due to physics in unity but bc of the code
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    
    // color red when clicked
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    // change color to white when un-clicked
    void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * -500);

        GetComponent<SpriteRenderer>().color = Color.white;
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
