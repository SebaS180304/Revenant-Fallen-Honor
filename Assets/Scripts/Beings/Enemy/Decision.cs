using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Decision : MonoBehaviour
{
    //Options
    [SerializeField] private Transform[] patrolPoints;
    private int point;
    private Transform player;
    private Transform objective;
    //Constants
    private float MAX_DIST = 16;

    // States
    private bool coolDown;
    private bool rightF;
    //Components

    private Transform transform;
    private Animator animator;

    private void Awake() {
        transform = GetComponent<Transform>();

        animator = GetComponent<Animator>();
    }
    void Start()
    {
        point = 1;
        rightF = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!coolDown){
            if(Vector2.Distance(transform.position,patrolPoints[point].position)> MAX_DIST ){
                animator.SetBool("InPatrol", true);
                
                objective = patrolPoints[point];

            }
            else if (player != null){
                
                animator.SetBool("InPatrol", false);
                objective = player;

            }
            else{
                
                animator.SetBool("InPatrol", true);
                objective = patrolPoints[point];
            }
            Turn();
            StartCoroutine(DecisionCD());
            

        }
                
    }

    

    public Transform getObjective(){
        return objective;
    }
    public void setPlayer(Transform ply){
        player = ply;
    }

    public void setPoint(){
        point++;
        if(point >= patrolPoints.Length){
            point = 0;
        }
    }
    private IEnumerator DecisionCD(){
        coolDown = true;
        yield return new WaitForSeconds(0.6f);
        coolDown = false;
    }

    private void Turn(){
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
