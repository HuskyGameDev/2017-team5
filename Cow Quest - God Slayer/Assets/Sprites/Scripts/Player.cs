using UnityEngine;

using System.Collections;



public class Player : MonoBehaviour
{



    public float maxSpeed = 5f;

    public float moveForce = 100f;

    public float jumpPower = 3000f;

    public bool grounded = false;

    [HideInInspector] public bool jump = false;


    private Rigidbody2D rb2d;

    public Transform groundCheck;


    void Start()

    {

        rb2d = GetComponent<Rigidbody2D>();
        
    }



    void Update()

    {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }



    void FixedUpdate()

    {

        float h = Input.GetAxis("Horizontal");

    

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpPower));
            jump = false;
        }

    }

}
