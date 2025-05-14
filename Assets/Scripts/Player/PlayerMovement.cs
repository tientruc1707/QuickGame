using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private ParticleSystem _smokeEffect;
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 250f;
    private float _inputHorizontal;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 210f;
    private bool _onGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _onGrounded = true;
        _smokeEffect = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_inputHorizontal * _moveSpeed * Time.deltaTime, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(_inputHorizontal));
        if (_inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        animator.SetBool("Jump", !_onGrounded);
    }
    public void Move(InputAction.CallbackContext context)
    {
        _inputHorizontal = context.ReadValue<Vector2>().x;
        _smokeEffect.Play();
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_RUN);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (OnGrounded())
        {
            _onGrounded = false;
            if (context.performed)
            {
                //Hold the jump button to jump higher
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce * Time.deltaTime);
            }
            else if (context.canceled)
            {
                //Light tap of jump button to jump lower (double jump)
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce * 0.5f * Time.deltaTime);
            }
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
    // Check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.GROUND))
        {
            _onGrounded = true;
        }
        if (other.gameObject.CompareTag(StringConstant.TAGS.ENEMY))
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
