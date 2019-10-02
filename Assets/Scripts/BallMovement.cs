using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    Vector2 ScreenBounds;
    Vector3 random;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        random= Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f));
        rb.velocity = speed * random; 
        ScreenBounds = GameManager.ScreenBounds;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Bat") {
            
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if ((ScreenBounds.x*-1)<transform.position.x || transform.position.x< ScreenBounds.x)
        {
            
            rb.velocity = new Vector2((-1) * rb.velocity.x, rb.velocity.y);
        }
        if ((ScreenBounds.y * -1) < transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x,(-1) * rb.velocity.y);
        }

            rb.gravityScale = 0.0f;
        
    }
}
