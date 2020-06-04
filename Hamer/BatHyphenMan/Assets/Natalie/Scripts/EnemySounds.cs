using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : StateMachineBehaviour
{
    public Enemy_Controller EnemyScript;
    public int Sound;
    public bool Conditional;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyScript = animator.gameObject.GetComponentInParent<Enemy_Controller>();

        if (Conditional == false)
        {
            EnemyScript.CurrentSound = Sound;
            EnemyScript.AudioPlaying = true;
        }

        else if (Conditional == true)
        {
            if (Sound == 2)
            {
                if (animator.GetBool("IsHit?") == true)
                {

                }
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   // {
   // }

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
