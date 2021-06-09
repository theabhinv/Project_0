using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public float RayCastLine = .5f;
    public float groundCheckRadius;
    public float WallCheckRadius;
    public LayerMask groundLayer;
    public bool IsGrounded = false;
    //public bool IsWalled;
    public float WallJumpSpeed = 10f;
    public float time;
    public float Score = 0f;
    public bool Raycasthit;


    //public List<Transform> groundCheckPoint = new List<Transform>();
    [SerializeField]
    private Transform groundCheckPoint_1;
    [SerializeField]
    private Transform Hit_left;
    [SerializeField]
    private Transform Hit_Right;
    public float health = 10f;
    
    private float damage = 1f;
    private float movement = 6f;
    private Rigidbody2D rb2d;
    
    
    

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Move;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint_1.position, -transform.up, groundCheckRadius, groundLayer);
        
        RaycastHit2D hit_1 = Physics2D.Raycast(Hit_left.position, transform.right, WallCheckRadius, groundLayer);
        RaycastHit2D hit_2 = Physics2D.Raycast(Hit_Right.position, -transform.right, WallCheckRadius, groundLayer);
        IsGrounded = false;
        
        //IsWalled = false;
        if (hit)
        {
            Debug.DrawRay(groundCheckPoint_1.position,Vector3.down,Color.red);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            
            IsGrounded = true;
        }
        
        
        
        movement = Input.GetAxis("Horizontal");
        if (movement >= 0.75f)
        {
            Move = new Vector2(movement * speed, rb2d.velocity.y);
        }
        else if (movement <= 0.75f)
        {
            Move = new Vector2(movement * speed, rb2d.velocity.y);
        }
        else
        {
            Move = new Vector2(0.1f, rb2d.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded==true)
        {
            Move = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Space)  && hit_2 == true)
        {
            
            Move = new Vector2(jumpSpeed , WallJumpSpeed);

        }
        else if (Input.GetKeyDown(KeyCode.Space)  && hit_1 == true)
        {
            Move = new Vector2(-jumpSpeed , WallJumpSpeed);

        }

        rb2d.velocity = Vector3.Lerp(rb2d.velocity, Move, time);

    }

    
}