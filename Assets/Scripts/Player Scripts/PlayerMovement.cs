using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField] private float moveSpeed = 2f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        
        if (Input.GetAxisRaw("Horizontal") < 0f)
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }



} // class
