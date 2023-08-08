using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player properties")]
    private Rigidbody2D myRB;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
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

}
