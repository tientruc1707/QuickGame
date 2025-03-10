
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalAttacking : MonoBehaviour
{
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private int _count = 1;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PerformAttack(_count);
            _count++;
        }
    }
    private void PerformAttack(int count)
    {
        switch (count)
        {
            case 1:
                _animator.SetTrigger("Attack1");
                break;
            case 2:
                _animator.SetTrigger("Attack2");
                break;
            case 3:
                _animator.SetTrigger("Attack3");
                break;
        }
    }
}
