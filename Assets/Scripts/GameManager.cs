using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallMovement ball;
    public BatMovement bat;
    [HideInInspector]public static Vector2 ScreenBounds;
    Vector3 batPosition;
    float BatHeight;
    public float offsetBat;
    private int tileNumber;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("You Win!");
        }
    }
}
