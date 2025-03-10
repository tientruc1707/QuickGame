using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 250f;
    [SerializeField] private float _inputHorizontal;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 210f;
    [SerializeField] private bool _onGrounded;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 2f;
    [SerializeField] private float _dashCooldown = 2f;
    [SerializeField] private float _nextDashTime = 0f;
    [SerializeField] private Slider _dashSlider;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _onGrounded = true;
    }
    private void Update()
    {
        _dashSlider.value = Mathf.Clamp(_nextDashTime - Time.time, 0, _dashCooldown) / _dashCooldown;
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
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > _nextDashTime)
        {
            Debug.Log("Dash");
            this.transform.position += new Vector3(_dashForce, 0, 0);
            animator.SetBool("Dash", true);
            _nextDashTime = Time.time + _dashCooldown;
        }
        else
        {
            animator.SetBool("Dash", false);
        }
    }
    // Check if the player is near the ground
    private bool OnGrounded()
    {
        Color rayColor = Color.red;
        float rayLenght = 1f;
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
        if (other.gameObject.CompareTag("Ground"))
        {
            _onGrounded = true;
        }
    }
}
