using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameObject player;
    private Transform objective;
    [SerializeField] private int MAX_DIST;
    private bool rightF;
    //Components
    private Transform transform;
    private Animator animator;
    
    // Start is called before the first frame updat

    // Update is called once per frame

    private void Start() {
        rightF = true;
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(player != null){
            objective = player.GetComponent<Transform>();
            if(Vector2.Distance(transform.position,objective.position)> MAX_DIST ){
                animator.SetInteger("State", -1);
            }else{
                animator.SetInteger("State", -1);
            }
        }
        else{
            animator.SetInteger("State", 2);
        }
        
    }

    public GameObject getPlayer(){
        return player;
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
