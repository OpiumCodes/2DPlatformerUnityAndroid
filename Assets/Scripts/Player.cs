using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private KeyCode moveUp;
    private KeyCode moveDown;
    private KeyCode moveRight;
    private KeyCode moveLeft;
    private int speed = 12;

    private Vector2 touchOrigin = -Vector2.one;
    // Use this for initialization
    void Start()
    {
        moveUp = KeyCode.UpArrow;
        moveDown = KeyCode.DownArrow;
        moveRight = KeyCode.RightArrow;
        moveLeft = KeyCode.LeftArrow;
        rb = GetComponent<Rigidbody2D>();
    }
    void MoveUp(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, speed);
    }
   
    void MoveLeft(Rigidbody2D rb)
    {
         rb.velocity = new Vector2(speed / 2, 0);
    }
    void MoveRight(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(-1*speed / 2, 0);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(moveUp))
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            rb.velocity = new Vector2(0, speed * -1);
        }
        else if(Input.GetKey(moveRight))
        {
            rb.velocity = new Vector2(speed / 2, 0);
        }
        else if (Input.GetKey(moveLeft))
        {
            rb.velocity = new Vector2(-1*speed / 2, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}