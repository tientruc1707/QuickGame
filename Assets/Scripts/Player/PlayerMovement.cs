
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float _moveSpeed = 5f;
    private float _inputHorizontal;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_inputHorizontal * _moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(_inputHorizontal));
        if (_inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        _inputHorizontal = context.ReadValue<Vector2>().x;
    }
}
