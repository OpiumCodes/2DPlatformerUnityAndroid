using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f, jumpvelocity = 60f;//Speed se adauga la vectorul de velocity al caracterului pentru a-l misca cu atatia pixeli jump la fel
    private Transform myTransform;//Asta e un fel de state of an object
    private Rigidbody2D myRB;//Asta e playerul principal
    public LayerMask Ground;//Cu asta arat indicatorului de ground ce este un ground, adica un layer in plus ce il pun peste obiectele ce le consider ground
    public Transform GroundCheck;//Asta e indicator daca e grounded sau nu
    private float groundCheckRadius = 0.1f;//Asta e radius-ul checkului de ground adica daca ceva din layerul ground intra in acel cerc se schimba starea sa
    public bool Grounded;//Asta e indicele de grounded daca e activ se poate apela Jump
    private float hInput =0;//Asta il folosesc pentru a face legatura dintre butoane si functia move
    private Vector2 startPoint;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();//Player
        myTransform = this.transform;//Starea Player
        startPoint = myTransform.position;
    }

    void FixedUpdate()
    {
        Debug.Log("Velocity="+myRB.velocity);
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, Ground);
#if UNITY_ADROID//Cu asta verific daca e pe android sau nu, adica pe desktop sa mearga butoanele si pe android doar alea de pe ecran
        Move(Input.GetAxisRaw("Horizontal"));//Asta verifica daca e input pe axa stanga dreapta si o apeleaza
        if (Input.GetButtonDown("Jump"))//Asta verifica daca e input default de jump adica space sau sageata sus
        {
            Jump();//Functia de jump definita mai jos
        }
#else
        if(hInput!=0)
            Move(hInput);//Asta e functia speciala pentru mutat cu input din UI care practic face acelasi lucru ca si Move doar ca tine minte o stare ca sa se miste smooth
#endif

    }
    void Move(float horizontalInput)
    {
        myRB.velocity = new Vector2(horizontalInput*speed,0);//Adauga le vectorul de velocity input orizontal adica -1 sau +1 stanga/dreapta * viteza pe axa stanga dreapta
    }
    public void Jump()
    {
        Debug.Log("Jump pressed");
        if (Grounded)//Daca e grounded
        {
            myRB.velocity += jumpvelocity * Vector2.up;//Inmulteste velocity de sus cu cat vrei sa sara in float 
            Debug.Log(myRB.velocity);
        }

    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;//Asta e doar sa retina starea de move sau stay ca altfel e snappy pentru butoane de UI
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="killbox")
        {
            myRB.position = startPoint;
        }
    }
}
