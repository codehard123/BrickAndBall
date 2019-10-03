using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class PartcileSystemTiles : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ps;
    ParticleSystem pss;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("ParticleSystem");
        pss = ps.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Tile")
        pss.Play();
        
    }
    private void FixedUpdate()
    {
        pss.transform.position = transform.position;
        
    }
}
