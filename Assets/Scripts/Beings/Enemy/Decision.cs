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
    private float MAX_DIST = 4;
    public Color attack;
    public Color Idle;

    // States
    private bool coolDown;
    private bool rightF;
    //Components
    private SpriteRenderer sp;
    private Transform transform;
    private Animator animator;

    private void Awake() {
        transform = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
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
                sp.color = Idle;
            }
            else if (player != null){
                
                animator.SetBool("InPatrol", false);
                objective = player;
                sp.color = attack;
            }
            else{
                
                animator.SetBool("InPatrol", true);
                objective = patrolPoints[point];
                sp.color = Idle;
            }
            Turn();
            StartCoroutine(DecisionCD());
            

        }
                
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            player = other.gameObject.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            player = null;
        }
    }

    public Transform getObjective(){
        return objective;
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
