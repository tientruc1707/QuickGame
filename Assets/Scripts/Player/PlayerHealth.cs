using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private int _healthAmount = 20;
    private int _playerHP = StringConstant.PLAYER_DETAIL.HEALTH;
    private int _currentHP;
    private Animator _animator;
    private void Start()
    {
        _currentHP = _playerHP;
        _animator = GetComponent<Animator>();
        EventManager.Instance.StartListening("Heal", OnHeal);
    }

    private void OnHeal()
    {
        Heal(_healthAmount);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening("Heal", OnHeal);
    }
    private void Update()
    {
        if (_currentHP <= 0)
        {
            Dead();
        }
    }
    public int CurrentHealth()
    {
        return _currentHP;
    }
    public void TakeDamage(int amount)
    {
        _currentHP -= amount;
        _currentHP = Mathf.Clamp(_currentHP, 0, _playerHP);
        // if(amount <= 20)
        // {
        //     _animator.SetTrigger("Hurt");
        // }
        // else
        // {
        //     _animator.SetTrigger("HurtHeavy");
        // }
    }

    public void Heal(int amount)
    {
        _currentHP += amount;
        _currentHP = Mathf.Clamp(_currentHP, 0, _playerHP);
    }

    public void Regen()
    {
        _currentHP = _playerHP;
    }
    public void Dead()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.DEFEAT);
    }
}
