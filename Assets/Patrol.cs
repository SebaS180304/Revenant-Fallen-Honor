using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private Transform transform;
    private Transform Objective;
    [SerializeField] private float speed;
    private bool finded;
    private float dist;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        finded = false;
        transform =animator.GetComponent<Transform>();
        Objective = animator.GetComponent<Decision>().getObjective();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Objective = animator.GetComponent<Decision>().getObjective();
        transform.position = Vector2.MoveTowards(transform.position, Objective.position, speed * Time.fixedDeltaTime);
        dist = Vector2.Distance(transform.position, Objective.position);
        if( dist<= 0.1f && !finded ){
            animator.GetComponent<Decision>().setPoint();
            finded = true;
        }
        else if(dist > 0.1f){
            finded = false;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
