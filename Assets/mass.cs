﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().mass = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
