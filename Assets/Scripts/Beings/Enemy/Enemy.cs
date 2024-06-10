using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Being
{
    //Components
    private Rigidbody2D RB2D;
    void Awake(){
        RB2D = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
