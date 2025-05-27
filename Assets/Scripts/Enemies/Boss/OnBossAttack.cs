using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnBossAttack : StateMachineBehaviour
{
    BoxCollider2D _boxCollider;
    PolygonCollider2D _polygonCollider;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boxCollider = animator.GetComponent<BoxCollider2D>();
        _polygonCollider = animator.GetComponent<PolygonCollider2D>();

        _boxCollider.enabled = false;
        _polygonCollider.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boxCollider.enabled = true;
        _polygonCollider.enabled = false;
    }

}
