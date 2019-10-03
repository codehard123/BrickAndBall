using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTile : MonoBehaviour
{
   
    public GameObject powerup;
    int currentSprite = 0;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        int random = Random.Range(1,5);
        if(true)
        {
          Instantiate(powerup.transform.GetChild((int)(Random.Range(0, powerup.transform.childCount))),collision.transform.position,Quaternion.identity);
       
        }
        Destroy(this.gameObject);
    
    }
    
}
