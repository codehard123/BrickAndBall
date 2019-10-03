using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int SceneCount = 0;
    public BallMovement ball;
    public BatMovement bat;
    [HideInInspector]public static int lives = 3;
    [HideInInspector]public int Score = 0;
    [HideInInspector]public int Level = 1;
    [HideInInspector]public static Vector2 ScreenBounds;
    Vector3 batPosition;
    float BatHeight;
    public float offsetBat;
    private int tileNumber;
    public ParticleSystem ps;
    public  GameObject powerup;
    public BoxCollider2D left;
    public BoxCollider2D right;
    public BoxCollider2D top;
    public static int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        left.offset = new Vector2(ScreenBounds.x, 0f);
        left.size = new Vector2(0.1f, -2*ScreenBounds.y);
        right.offset = new Vector2(-ScreenBounds.x, 0f);
        right.size = new Vector2(0.1f,-ScreenBounds.y*2);
        top.size = new Vector2(-ScreenBounds.x*2,0.1f);
        top.offset = new Vector2(0f,-ScreenBounds.y);
        
        BatHeight = (bat.gameObject.GetComponent<SpriteRenderer>().bounds.size.y) / 2;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        batPosition = new Vector3(0, ScreenBounds.y+(BatHeight/2)+offsetBat, 0f);
        Instantiate(bat.gameObject, batPosition, Quaternion.identity);
        Instantiate(ball.gameObject);
        Instantiate(ps, ball.transform.position, Quaternion.identity);
       
        Debug.Log("Tile Number" + tileNumber);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        tileNumber = GameObject.FindGameObjectWithTag("Level").transform.childCount;
        if(tileNumber==0)
        {
            SceneCount = SceneCount + 1;
            if(SceneCount<Application.levelCount)
            Application.LoadLevel(SceneCount);
        }
    }
}
