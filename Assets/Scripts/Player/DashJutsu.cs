using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashJutsu : ISkill
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerTransform;

    private float _dashForce = 25f;
    private float _dashCooldown = 2f;
    private float _lastExecution = 0f;
    void Update()
    {
        GetCoolDownTime();
    }
    public override float GetCoolDownTime()
    {
        float cooldown = Mathf.Clamp(Time.time - _lastExecution, 0, _dashCooldown) / _dashCooldown;
        return cooldown;
    }
    public override void ExecuteSkill()
    {
        if (Time.time - _lastExecution > _dashCooldown)
        {
            _playerTransform.position += _playerTransform.right * _dashForce * Time.deltaTime;
            _animator.SetTrigger("Dash");
            _lastExecution = Time.time;
        }
    }
}
