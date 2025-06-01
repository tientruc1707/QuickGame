using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;


    [SerializeField] private ParticleSystem _smokeEffect;
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 250f;
    private float inputHorizontal;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 2f;

    //_onGround for double jump
    [SerializeField] private bool isOnGrounded = false;
    [SerializeField] private bool jumping = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _smokeEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded())
        {
            jumping = true;
            isOnGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
    }
    //Run
    private void Move()
    {
        
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * _moveSpeed * Time.deltaTime, rb.velocity.y);

        if (inputHorizontal > 0)
        {
            sprite.flipX = false;
        }
        else if (inputHorizontal < 0)
        {
            sprite.flipX = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        _smokeEffect.Play();
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_RUN);
    }
    // Jump
    private void Jump()
    {
        animator.SetBool("Jump", !isOnGrounded);
        if (jumping)
        {
            if (OnGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            }
            jumping = false;
        }
    }
    // Check if the player is near the ground
    private bool OnGrounded()
    {
        Color rayColor = Color.red;
        float rayLenght = 2f;
        Vector2 rootPosition = transform.position;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(rootPosition, Vector2.down, rayLenght, layerMask);
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(rootPosition, Vector2.down * rayLenght, rayColor);
        return hit.collider != null;
    }
    // Check if the player has collider with somethings
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.GROUND))
        {
            isOnGrounded = true;
        }
        if (other.gameObject.CompareTag(StringConstant.TAGS.ITEM))
        {
            IIItem item = other.gameObject.GetComponent<IIItem>();
            if (item != null)
            {
                item.OnItemPickup();
                AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.ITEM_PICKUP);
                item.ReturnItemToPool();
            }
        }
    }

}
