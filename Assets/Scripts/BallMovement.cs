using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class BallMovement : MonoBehaviour
{
    public GameObject barrel;
    
    Rigidbody2D rb;
    public int speed;
    Vector2 ScreenBounds;
    bool inPlay = false;
    Vector3 random;
    GameObject bat;
    
    public GameObject leftEnd;
    public GameObject rightEnd;
    float distance;
    float dist;
    public float multiplier;
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        ScreenBounds = GameManager.ScreenBounds;
        bat = GameObject.FindGameObjectWithTag("Bat");
        placeBall();
        barrel = GameObject.FindGameObjectWithTag("barrel");
       
        
    }
    void LaunchBall() {
        float dist = transform.position.x - bat.transform.position.x;
        transform.rotation=Quaternion.AngleAxis(-dist*50f,Vector3.forward);

        rb.velocity = speed * transform.up;
        inPlay = true;
    }
    void placeBall() {
        this.GetComponent<Renderer>().material.color = Color.white;
        bat.transform.localScale = new Vector3((BatMovement.BatWidth) / 4, bat.transform.localScale.y, 0.1f);
        Vector2 a = barrel.transform.position;
        Time.timeScale = 1f;
        
        Vector2 b = transform.position;
        rb.velocity = Vector3.zero;
        distance = Vector2.Distance(a, b);

       
       
        dist = Random.Range(-BatMovement.BatWidth / 2, BatMovement.BatWidth / 2);
        inPlay = false;
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        Debug.Log(rb.velocity.x + "," + rb.velocity.y);
      
        
       
        if(transform.position.y < ScreenBounds.y)
        {
            //Play Animation
            GameManager.lives = GameManager.lives - 1;
            
            placeBall();
            Debug.Log(ScreenBounds.y);

        }
        
        if(!inPlay && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
        if(inPlay==false)
        {
            transform.position = new Vector3(bat.transform.position.x+dist, bat.transform.position.y, 0f);
        }
        rb.gravityScale = 0.0f;
        
    }
}
