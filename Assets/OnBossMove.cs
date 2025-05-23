using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossMove : StateMachineBehaviour
{
    public float _speed;
    public float _attackRange;
    Transform _player;
    Rigidbody2D _rb;
    Boss _boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = animator.GetComponent<Rigidbody2D>();
        _boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new(_player.position.x, _rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(_rb.position, target, _speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPos);
        if (Vector2.Distance(_player.position, _rb.position) <= _attackRange)
        {
            animator.SetTrigger("Attack");
        }
        _boss.LookAtPlayer(_player);
        Jump(_boss.GetDirection(), animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset any parameters or states if needed
        animator.ResetTrigger("Attack");
    }
    private void Jump(int direction, Animator animator)
    {
        Color color = Color.red;
        float rayLength = 1f;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.left * direction, rayLength, layerMask);
        if (hit.collider != null)
        {
            animator.SetTrigger("Jump");
            _rb.AddForce(new Vector2(direction, 1) * 2, ForceMode2D.Impulse);
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
        Debug.DrawRay(_rb.position, Vector2.left * direction * rayLength, color);

    }
}
