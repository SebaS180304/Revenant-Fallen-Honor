using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Being
{
    //Components
    private Rigidbody2D RB2D;
    private Transform transfrom;
    private Animator animator;
    //Vairiables
    private int spawnDist;
    //Constants
    private int DMG;
    

    void Awake(){
        RB2D = GetComponent<Rigidbody2D>();
        transfrom = GetComponent<Transform>();
        animator = GetComponent<Animator>();
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
        try{
            other.gameObject.GetComponent<Player>().GetHit(DMG, transfrom.position);
        }catch(Exception e){
            Debug.Log("Choco");
        }
    }

    public override void GetHit(int DMG, Vector2 Pos){
        
        Vector2 origin = transform.position;
        Vector2 vectorU = (origin-Pos).normalized;
        if(!inbulnerable){
            health -= DMG;
            if (health <= 0)
            {
                StartCoroutine(Dead());
            }else{

                //Deactivate rb2d
                RB2D.isKinematic = false;
                RB2D.freezeRotation = true;
                RB2D.gravityScale = 0f;
                animator.SetTrigger("Hit");
                RB2D.AddForce(vectorU*600, ForceMode2D.Impulse);
                StartCoroutine(Inbulnerable(0.1f));
            }
            

        }

    }

    private IEnumerator Dead(){
        GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }


}
