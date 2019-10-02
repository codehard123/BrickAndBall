using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float BatWidth;

    Vector2 ScreenBounds;
    float minRange, maxRange;
    public float moveX = 15f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        BatWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        ScreenBounds = GameManager.ScreenBounds;   
        
        minRange = ScreenBounds.x + (BatWidth / 2);
        maxRange = (-1) * ScreenBounds.x - (BatWidth / 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
         if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right*moveX*Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveX * Time.deltaTime);

        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minRange, maxRange), transform.position.y, transform.position.z);
        rb.gravityScale = 0.0f;
        
    
    }
    
}
