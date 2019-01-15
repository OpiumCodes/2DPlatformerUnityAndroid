using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f, jumpvelocity = 10f;
    private Transform myTransform,tagGround;
    private Rigidbody2D myRB;
    private LayerMask playerMask;
    public bool isGround = false;
    void Start()
    {
        tagGround = GameObject.Find("tag_ground").transform;
        if (tagGround != null)
            Debug.Log("Found tag_ground");
        myRB = GetComponent<Rigidbody2D>();
        myTransform = this.transform;
    }

    void FixedUpdate()
    {
        isGround = Physics2D.Linecast(myTransform.position, tagGround.position);
        if(isGround==false)
        {
            Debug.Log("Not Touching Ground");
        }
        else
        {
            Debug.Log("Touching ground");
        }
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    public void Move(float horizontalInput)
    {
        myRB.velocity = new Vector2(horizontalInput*speed,0);
    }
    public void Jump()
    {
        if(isGround)
        myRB.velocity += jumpvelocity*Vector2.up;
    }
}
