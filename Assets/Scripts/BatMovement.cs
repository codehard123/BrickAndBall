using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static float BatWidth;
    GameObject ball;
    Vector2 ScreenBounds;
    float minRange, maxRange;
    public float moveX = 15f;
    public GameObject leftEnd;
   public   GameObject rightEnd;
    
    public GameObject gun;
    bool hasGun = false;

    void Start()
    {
        BatWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        ScreenBounds = GameManager.ScreenBounds;   
        
        minRange = ScreenBounds.x + (BatWidth / 2);
        maxRange = (-1) * ScreenBounds.x - (BatWidth / 2);
        ball = GameObject.FindGameObjectWithTag("Sphere");
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        string tag = collision.gameObject.tag;
        Destroy(collision.gameObject);
        if (tag == "oneUp")
        {
            GameManager.lives = GameManager.lives + 1;

        }
        if (tag == "2X")
        {
            Time.timeScale = 2f;
        }
        if (tag == "solidBall")
        {
            GameObject.FindGameObjectWithTag("Tile").GetComponent<BoxCollider2D>().enabled = false;
            ball.GetComponent<Renderer>().material.color = Color.blue;
        }
        if(tag=="extendedArrow")
        {
            this.gameObject.transform.localScale = new Vector3((this.gameObject.transform.localScale.x) * 2, (this.gameObject.transform.localScale.y) , (this.gameObject.transform.localScale.z));

        }
        if (tag == "compressArrow")
        {
            this.gameObject.transform.localScale = new Vector3((this.gameObject.transform.localScale.x) / 2, (this.gameObject.transform.localScale.y), (this.gameObject.transform.localScale.z));

        }
        
        if (tag == "bulletPowerup" && hasGun == false)
        {
            leftEnd = GameObject.FindGameObjectWithTag("LeftEnd");
            rightEnd = GameObject.FindGameObjectWithTag("RightEnd");
            Instantiate(gun, leftEnd.transform.position, Quaternion.identity);
            Instantiate(gun, rightEnd.transform.position, Quaternion.identity);
            hasGun = true;
        }
       
        if(tag=="dollar")
        {
            GameManager.score = GameManager.score * 2;
        }
        
        
        
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
        
    
    }

    
}
