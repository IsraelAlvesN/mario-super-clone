using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed = 5f;
    [Header("Jump properties")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int jumpForce = 15;
    [SerializeField] private bool isJump;
    [SerializeField] private bool inFloor = true;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        inFloor = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.blue);

        if (Input.GetButtonDown("Jump") && inFloor)
        {
            isJump = true;
        }
        else if (Input.GetButtonDown("Jump") && myRB.velocity.y > 0)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        Move();
        JumpPlayer();
    }

    private void Move()
    {
        var xMove = Input.GetAxis("Horizontal"); 

        myRB.velocity = new Vector2(xMove * speed, myRB.velocity.y);

        if(xMove > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (xMove < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void JumpPlayer()
    {
        if (isJump)
        {
            myRB.velocity = Vector2.up * jumpForce;
            isJump = false;
        }
    }

}
