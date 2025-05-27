using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossMove : StateMachineBehaviour
{
    public float _speed;
    private float _attackRange;
    private float _xAxis;
    private Transform _player;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Boss _boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _attackRange = (float)StringConstant.BOSS.ATTACK_RANGE;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = animator.GetComponent<Rigidbody2D>();
        _boss = animator.GetComponent<Boss>();
        _sprite = animator.GetComponent<SpriteRenderer>();
        _xAxis = _sprite.bounds.size.x / 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.transform.position = Vector2.MoveTowards(_rb.position, _player.position, _speed * Time.fixedDeltaTime);
        if (Vector2.Distance(_player.position, _rb.position) <= _attackRange)
        {
            animator.SetTrigger("Attack");
        }
        _boss.LookAtPlayer(_player);
        if (ObstacleDetection(_boss.GetDirection()))
        {
            _rb.velocity = new Vector2(_rb.velocity.x + _boss.GetDirection(), 6f);
            animator.SetTrigger("Jump");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset any parameters or states if needed
        animator.ResetTrigger("Attack");
    }

    //Check if have any ground in front ;
    private bool ObstacleDetection(int direction)
    {
        Color color = Color.red;
        float rayLength = _xAxis + 1f;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        Vector2 origin = _rb.GetComponent<Transform>().position + new Vector3(0f, 0.5f, 0f);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right * direction, rayLength, layerMask);
        if (hit.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
        Debug.DrawRay(_rb.position, direction * rayLength * Vector2.right, color);
        return hit.collider != null;
    }
}
