using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Being
{
    //Components
    private Rigidbody2D RB2D;
    private Transform transfrom;
    private int spawnDist;
    private int DMG;

    void Awake(){
        RB2D = GetComponent<Rigidbody2D>();
        transfrom = GetComponent<Transform>();
        MAX_HEALTH = 12;
    }
    void Start()
    {
        spawnpoint  = transfrom.position;
        health  = MAX_HEALTH;
        DMG = 5;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.GetComponent<Player>() != null){
            other.gameObject.GetComponent<Player>().GetHit(DMG, transfrom.position);
        }
    }


}
