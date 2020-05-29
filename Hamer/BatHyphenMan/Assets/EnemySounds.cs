using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : StateMachineBehaviour
{
    public Enemy_Controller EnemyScript;
    public int Sound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyScript = animator.gameObject.GetComponentInParent<Enemy_Controller>();

        if (EnemyScript.CurrentMovementSound != Sound)
        {
            EnemyScript.PreviousMovementSound = EnemyScript.CurrentMovementSound;
            EnemyScript.CurrentMovementSound = Sound;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyScript.PreviousMovementSound = EnemyScript.CurrentMovementSound;
        EnemyScript.CurrentMovementSound = 0;
    }

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
