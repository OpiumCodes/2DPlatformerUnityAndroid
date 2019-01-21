using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D enemyBody;
    Transform myTransform;
    float myWidth, myHeight;
    void Start()
    {
        myTransform = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myHeight = mySprite.bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lineCastPos = toVector2(myTransform.position) - toVector2(myTransform.right) * myWidth + Vector2.down* myHeight;

        Vector2 velocity = enemyBody.velocity;
        velocity.x = -myTransform.right.x * speed;
        enemyBody.velocity = velocity;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down,enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - toVector2(myTransform.right) *0.5f ,enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - toVector2(myTransform.right) * .05f);


        if (!isGrounded || isBlocked)
        {
            Vector3 rot = myTransform.eulerAngles;
            rot.y += 180;
            myTransform.eulerAngles = rot;

        }

        
    }
    Vector2 toVector2(Vector3 v3)
    {
        return new Vector2(v3.x,v3.y);
    }

}

