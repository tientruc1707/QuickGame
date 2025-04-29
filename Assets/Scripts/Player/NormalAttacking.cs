
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalAttacking : MonoBehaviour
{
    private Animator _animator;
    private float _comboTiming = 0.5f;
    private float _lastHit = 0f;
    private int _count = 1;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.time - _lastHit > _comboTiming)
            {
                _count = 1;
            }
            PerformAttack(_count);
            AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_HIT);
            _lastHit = Time.time;
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
