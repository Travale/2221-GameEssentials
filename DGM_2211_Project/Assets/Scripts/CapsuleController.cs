using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    
    private bool isGrounded;
    public Tranform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;

    public int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity= new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
            
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = 2;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    
    
    
    
    


}
