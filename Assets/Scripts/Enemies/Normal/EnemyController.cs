using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I need to add chasing and attacking player

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private EnemyHealth _enemyHealth;
    private Vector3 _startPosition;

    private int _speed;
    private int _range;



    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startPosition = transform.position;

        _enemyHealth = GetComponent<EnemyHealth>();
        _speed = _enemyHealth._enemyDetail.Speed;
        _range = _enemyHealth._enemyDetail.MovingRange;

    }

    void Update()
    {
        OnMoving();
    }

    private void OnMoving()
    {

        if (transform.position.x > _startPosition.x + _range)
        {
            MoveLeft();
        }
        else if (transform.position.x < _startPosition.x - _range)
        {
            MoveRight();
        }
        else
        {
            if (_spriteRenderer.flipX)
                MoveRight();
            else
                MoveLeft();
        }
        _animator.SetBool("Move", true);
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        _spriteRenderer.flipX = false;
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _spriteRenderer.flipX = true;
    }

    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }
}
