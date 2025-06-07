using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OnBossMove : StateMachineBehaviour
{
    public float Speed;
    private float attackRange;
    private float xAxis;
    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Boss boss;
    private Boss_Attack boss_Attack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackRange = (float)StringConstant.BOSS.ATTACK_RANGE;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        sprite = animator.GetComponent<SpriteRenderer>();
        boss_Attack = animator.GetComponent<Boss_Attack>();
        xAxis = sprite.bounds.size.x / 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.transform.position = Vector2.MoveTowards(rb.position, player.position, Speed * Time.fixedDeltaTime);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (boss_Attack.Attackable())
            {
                switch (Random.Range(1, 4))
                {
                    case 1:
                        animator.SetTrigger("Attack1");
                        break;
                    case 2:
                        animator.SetTrigger("Attack2");
                        break;
                    case 3:
                        animator.SetTrigger("Attack3");
                        break;
                }
            }
        }

        boss.LookAtPlayer(player);

        if (ObstacleDetection(boss.GetDirection()))
        {
            rb.velocity = new Vector2(rb.velocity.x + boss.GetDirection(), 6f);
            animator.SetTrigger("Jump");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");
    }

    //Check if have any ground in front 
    private bool ObstacleDetection(int direction)
    {
        Color color = Color.red;
        float rayLength = xAxis + 1f;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        Vector2 origin = rb.GetComponent<Transform>().position + new Vector3(0f, 0.5f, 0f);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right * direction, rayLength, layerMask);
        if (hit.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
        UnityEngine.Debug.DrawRay(rb.position, direction * rayLength * Vector2.right, color);
        return hit.collider != null;
    }
}
