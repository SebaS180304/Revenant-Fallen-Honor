
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameObject player;
    private Transform objective;
    [SerializeField] private int MAX_DIST;
    private bool rightF;
    public int count;
    //Components
    private Transform transform;
    private Animator animator;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame updat

    // Update is called once per frame

    private void Awake() {
        rightF = true;
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(player != null){
            objective = player.GetComponent<Transform>();
            if(Math.Abs(getDist())> MAX_DIST ){
                animator.SetInteger("State", -1);
            }else{
                animator.SetInteger("State", 1);
            }
        }
        else{
            animator.SetInteger("State", 2);
        }

        animator.SetFloat("VelY", rb2d.velocity.y);
    }

    public GameObject getPlayer(){
        return player;
    }
    public float getDist(){
        return objective.position.x-transform.position.x;
    }
    public void setPlayer(GameObject ply){
        player = ply;
    }

    public void Turn(){
        if(rightF && (transform.position.x > objective.position.x)){
            transform.Rotate(0f,180f,0f);
            rightF = false;
        }
        if(!rightF && (transform.position.x < objective.position.x)){
            transform.Rotate(0f,180f,0f);
            rightF = true;
        }
    }
}
