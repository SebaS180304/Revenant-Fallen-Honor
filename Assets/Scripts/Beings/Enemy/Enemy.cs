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
        inbulnerable = false;
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

    public override void GetHit(int DMG, Vector2 Pos){
        Vector2 origin = transform.position;
        Vector2 vectorU = (origin-Pos).normalized;
        if(!inbulnerable){
            health -= DMG;
            if (health <= 0)
            {
                Dead();
            }else{
                //RB2D.AddForce(vectorU*50, ForceMode2D.Impulse);
                StartCoroutine(Inbulnerable());
            }
            

        }

    }

    private void Dead(){
        GetComponent<Animator>().SetTrigger("Dead");
    }


}
