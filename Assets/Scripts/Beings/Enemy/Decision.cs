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
    private Transform transform;
    //Constants
    private float MAX_DIST;

    // States
    private bool coolDown;
    private void Awake() {
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        point = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!coolDown){
            if(Vector2.Distance(transform.position,patrolPoints[point].position)> MAX_DIST ){
            objective = patrolPoints[point];
            }
            else if (player != null){
                objective = player;
            }
            else{
                objective = patrolPoints[point];
            }
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
        if(point > patrolPoints.Length){
            point = 0;
        }
    }
    private IEnumerator DecisionCD(){
        coolDown = true;
        yield return new WaitForSeconds(3f);
        coolDown = false;
    }
}
