using UnityEngine;
using System.Collections;



public class Player : MonoBehaviour
{



    public float maxSpeed = 5f;
    public float moveForce = 1000f;
    public float jumpForce = 1000f;
    private bool grounded = false;
    private int counter = 0;
    private LifeCounter life;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool facingRight = true;


    private Rigidbody2D rb2d;
    private Animator anim;
    public Transform groundCheck;


    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
	rb2d.freezeRotation = true;
        life = FindObjectOfType<LifeCounter>();
	anim = GetComponent<Animator>();
    }

    

    void Update(){
        anim = GetComponent<Animator>();
	Vector3 pos = new Vector3(0, -5, 0);
	grounded = Physics2D.Linecast(groundCheck.position, groundCheck.position, 9 << LayerMask.NameToLayer("Ground"));
	Debug.DrawLine(groundCheck.position, groundCheck.position, Color.red, 100, false);

        if (transform.position.y < -50){
            life.RemoveFromLives();
	   rb2d.velocity = new Vector2(0f, 0f);
            transform.position = new Vector3(0, 0, 0);
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && grounded){
            jump = true;
        }
	
	rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * 0.1f, rb2d.velocity.y);

	

	
    }

  

 
    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
	
	anim.speed = Mathf.Abs(h);
	
      	if (h * rb2d.velocity.x < maxSpeed){
            rb2d.AddForce(Vector2.right * h * moveForce);
	}

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed){
            rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
	}

	if (h > 0 && !facingRight)
            Flip ();
        else if (h < 0 && facingRight)
            Flip ();

        if (jump){
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

  void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}