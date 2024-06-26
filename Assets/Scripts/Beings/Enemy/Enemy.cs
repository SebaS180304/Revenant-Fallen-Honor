using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Being
{
    //Components
    private Rigidbody2D RB2D;
    private Transform transform;
    private Animator animator;


    //Vairiables
    private int spawnDist;
    //Constants
    private int DMG;
    private int contactForce;
    

    void Awake(){
        
        RB2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();

    }
    void Start()
    {
        inbulnerable = false;
        spawnpoint  = transform.position;
        health  = MAX_HEALTH;
        DMG = 5;
        contactForce = 25;

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnCollisionStay2D(Collision2D other) {
        try{
            other.gameObject.GetComponent<Player>().GetHit(DMG, transform.position,contactForce );
        }catch(Exception e){
            Debug.Log("Choco");
        }
    }

    public override void GetHit(int DMG, Vector2 Pos){
        
        Vector2 origin = transform.position;
        Vector2 vectorU = (origin-Pos).normalized;
<<<<<<< Updated upstream
        health -= DMG;
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }else{
=======
            health -= DMG;
            if (health <= 0)
            {
                StartCoroutine(Dead());
            }else{
>>>>>>> Stashed changes

            //Deactivate rb2d
            if(RB2D.isKinematic){
                RB2D.isKinematic = false;
                RB2D.freezeRotation = true;
                RB2D.gravityScale = 0f;
                RB2D.AddForce(vectorU*600, ForceMode2D.Impulse);
<<<<<<< Updated upstream
            }
            animator.SetTrigger("Hit");
        

=======
>>>>>>> Stashed changes
        }

    }

    public override void GetHit(int DMG, Vector2 Pos, int knock){
        
        Vector2 origin = transform.position;
        Vector2 vectorU = (origin-Pos).normalized;
            health -= DMG;
            if (health <= 0)
            {
                StartCoroutine(Dead());
            }

    }

    private IEnumerator Dead(){
<<<<<<< Updated upstream
        //Instantiate(HealthPotion, transform.position, transform.rotation);
        GetComponent<Animator>().SetTrigger("Dead");
=======
        animator.SetTrigger("Dead");
>>>>>>> Stashed changes
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    public int getDMG(){
        return DMG;
    }

    public void Respawn(){
        animator.SetInteger("State", 0);
        transform.position = spawnpoint;
        health = MAX_HEALTH;
    }
}
