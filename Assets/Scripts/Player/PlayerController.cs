using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator animator;
    private int speed = StringConstant.PLAYER_DETAIL.SPEED;
    private int comboStep = 0;
    private float comboTimer = 0f;
    public float comboDelay = 1f;
    private bool onGround;
    public event Action isAttacking;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (comboTimer > 0)
            {
                comboStep++;
                comboStep = Mathf.Clamp(comboStep, 0, 3); // Assuming 3 combo steps
            }
            else
            {
                comboStep = 1;
            }

            comboTimer = comboDelay;
            PerformCombo(comboStep);
        }

        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
        else
        {
            comboStep = 0;
        }
    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            MoveRight();
        }
        else if (moveInput < 0)
        {
            MoveLeft();
        }
        animator.SetFloat("Running", Mathf.Abs(moveInput));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void MoveLeft()
    {
        rb2d.velocity = new Vector2(-speed * Time.deltaTime, rb2d.velocity.y);
        sprite.flipX = true;
    }
    private void MoveRight()
    {
        rb2d.velocity = new Vector2(speed * Time.deltaTime, rb2d.velocity.y);
        sprite.flipX = false;
    }
    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, StringConstant.PLAYER_DETAIL.JUMP_FORCE);
        animator.SetTrigger("Jumping");
        onGround = false;
    }
    void PerformCombo(int step)
    {
        animator.Play("Attack" + step);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            animator.ResetTrigger("Jumping");
        }
    }
    public void Attack()
    {
        isAttacking?.Invoke();
    }
}
