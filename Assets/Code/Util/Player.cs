using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 0.01f;
    private Rigidbody2D rb2D;
    private Transform playerTransform;
    private Vector2 autoWalking = new Vector2(5f, 0f);
    private SpriteRenderer playerSprite;
    private bool stickedToWall = false;
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        
        playerTransform = transform;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb2D.MovePosition(new Vector2(playerTransform.position.x + 0.01f, 0.0f));
        // playerTransform.
        if (Input.GetKeyDown(KeyCode.Space))
            if (collisionCount != 0)
                Jump();
        //buttonSpace.Execute();
    }

    private void FixedUpdate()
    {
        if (!stickedToWall)
            rb2D.velocity = new Vector2( autoWalking.x, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        collisionCount++;
        if (other.gameObject.CompareTag("Wall"))
            stickedToWall = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        collisionCount--;
        if (other.gameObject.CompareTag("Wall"))
            stickedToWall = false;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            stickedToWall = true;
        }
    }

    public void Jump()
    {
        rb2D.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        if (stickedToWall)
        {
            ReverseMovement();
            rb2D.velocity = new Vector2( autoWalking.x, rb2D.velocity.y);
        }
    }

    private void ReverseMovement()
    {
        autoWalking = autoWalking.x > 0 ? new Vector2(-5f, 0f) : new Vector2(5f, 0f);
        //Debug.Log("Changed movement direction");
        playerSprite.flipX = !playerSprite.flipX;
    }
}
