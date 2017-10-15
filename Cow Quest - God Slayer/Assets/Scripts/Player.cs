using UnityEngine;

using System.Collections;



public class Player : MonoBehaviour
{



    public float maxSpeed = 50f;

    public float moveForce = 365f;

    public float jumpPower = 150f;

    public bool grounded = false;


    private Rigidbody2D rb2d;

    public Transform groundCheck;

    private LifeCounter life;

    void Start()

    {

        rb2d = GetComponent<Rigidbody2D>();
        life = FindObjectOfType<LifeCounter>();

    }



    void Update()

    {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (transform.position.y < -100)
        {
           
            life.RemoveFromLives();

            transform.position = new Vector3(0, 0, 0);
        }


        }

  



        void FixedUpdate()

    {

        float h = Input.GetAxis("Horizontal");

    

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

      

    }

}
