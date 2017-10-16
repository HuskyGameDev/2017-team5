using UnityEngine;

using System.Collections;



public class Player : MonoBehaviour
{



    public float maxSpeed = 5f;
    public float moveForce = 10f;
    public float jumpForce = 300f;
    private bool grounded = false;
    private int counter = 0;
    private LifeCounter life;
    [HideInInspector] public bool jump = false;


    private Rigidbody2D rb2d;
    private Animator anim;
    public Transform groundCheck;


    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        life = FindObjectOfType<LifeCounter>();

    }

    

    void Update(){
        anim = GetComponent<Animator>();
        //Debug.Log(grounded + " " + counter++);
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 9 << LayerMask.NameToLayer("Ground"));
        if (transform.position.y < -100){
            life.RemoveFromLives();
            transform.position = new Vector3(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && grounded){
            jump = true;
        }
    }

  

 
    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (jump){
            grounded = false;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
