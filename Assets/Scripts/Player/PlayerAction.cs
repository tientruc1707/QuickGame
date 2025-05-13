
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private ISkill[] _skills;
    [SerializeField] private Animator _animator;

    public bool IsAttacking { get; private set; } = false;

    private float _comboTiming = 0.5f;
    private float _lastHit = 0f;
    private int _count = 1;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _skills[0].ExecuteSkill();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _skills[1].ExecuteSkill();
        }
        if (Input.GetMouseButtonDown(1))
        {
            IsAttacking = true;
            Attack();
        }
        IsAttacking = false;
    }
    public void Attack()
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
    public void pauseAnimation()
    {
        _animator.speed = 0;
    }
}
