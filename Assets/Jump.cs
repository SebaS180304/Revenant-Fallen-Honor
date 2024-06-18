using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateMachineBehaviour
{
    [SerializeField] private float jumpF;
    private Rigidbody2D rb2d;
    private Animator anime;
    private float dist;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
    anime = animator.GetComponent<Animator>();
    rb2d = animator.GetComponent<Rigidbody2D>();
    dist = animator.GetComponent<Boss>().getDist();
    rb2d.isKinematic = false;
    rb2d.freezeRotation = true;
    rb2d.gravityScale = 2f;
    rb2d.AddForce(new Vector2(dist, jumpF), ForceMode2D.Impulse);
    animator.GetComponent<Boss>().count++;
    anime.SetInteger("Count",animator.GetComponent<Boss>().count);
    
   }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
