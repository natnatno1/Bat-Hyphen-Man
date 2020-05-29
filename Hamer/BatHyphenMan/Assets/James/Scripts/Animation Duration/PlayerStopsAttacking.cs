using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopsAttacking : StateMachineBehaviour
{
    public Game_Manager GM;
    public AudioAndSoundEffects ASEScript;
    public int Sound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        ASEScript = GameObject.Find("SoundEffectsController").GetComponent<AudioAndSoundEffects>();

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ASEScript.CurrentSound = Sound;

        if (animator.GetBool("attacking?") == false)
        {
            GM.Attacking = false;
        }

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
