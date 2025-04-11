using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I need to add chasing and attacking player
public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private float range = StringConstant.ENEMY_DETAIL.ATTACK_RANGE;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    void Update()
    {
        OnMoving();
    }
    private void OnMoving()
    {

        if (transform.position.x > startPosition.x + range)
        {
            MoveLeft();
        }
        else if (transform.position.x < startPosition.x - range)
        {
            MoveRight();
        }
        else
        {
            if (spriteRenderer.flipX)
                MoveLeft();
            else
                MoveRight();
        }
        animator.SetBool("Run", true);
    }
    private void MoveLeft()
    {
        transform.Translate(Vector2.left * StringConstant.ENEMY_DETAIL.SPEED * Time.deltaTime);
        spriteRenderer.flipX = true;
    }
    private void MoveRight()
    {
        transform.Translate(Vector2.right * StringConstant.ENEMY_DETAIL.SPEED * Time.deltaTime);
        spriteRenderer.flipX = false;
    }
}
