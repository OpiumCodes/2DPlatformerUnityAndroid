using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f, jumpvelocity = 300f;
    private Transform myTransform,tagGround;
    private Rigidbody2D myRB;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float groundCheckRadius = 0.1f;
    public bool Grounded;
    private float hInput =0;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myTransform = this.transform;
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, Ground);
#if UNITY_ADROID
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
#else
        Move(hInput);
#endif

    }
    void Move(float horizontalInput)
    {
        myRB.velocity = new Vector2(horizontalInput*speed,0);
    }
    public void Jump()
    {
        Debug.Log("Jump pressed");
        if (Grounded)
        {
            myRB.velocity += jumpvelocity * Vector2.up;
            Debug.Log(myRB.velocity);
        }

    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }
}
