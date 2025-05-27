using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GokakyoNoJutsu : ISkill
{
    [SerializeField] private Animator _animator;
    private float _cooldown = 15f;
    private float _lastExecution = 0f;
    void OnDisable()
    {
        Animator anim = GetComponent<Animator>();
        anim.ResetTrigger("KatonGokakyoNoJutsu");
    }
    void Update()
    {
        GetCoolDownTime();
        if (Time.time - _lastExecution >= _animator.GetCurrentAnimatorStateInfo(0).length)
        {
            GameManager.Instance.UnfreezeObject(_animator.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    public override float GetCoolDownTime()
    {
        return Mathf.Clamp(Time.time - _lastExecution, 0, _cooldown) / _cooldown;
    }
    public override void ExecuteSkill()
    {
        if (Time.time - _lastExecution > _cooldown)
        {
            _animator.SetTrigger("KatonGokakyoNoJutsu");
            GameManager.Instance.FreezeObject(_animator.gameObject);
            GameManager.Instance.FreezeAllObjects(_animator.gameObject);
            AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.SKILL1);
            _lastExecution = Time.time;
        }
    }
    public void ActiveSkill()
    {
        Animator anim = GetComponent<Animator>();
        this.gameObject.SetActive(true);
        anim.SetTrigger("KatonGokakyoNoJutsu");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.ENEMY))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(5);
        }
        if (other.gameObject.CompareTag(StringConstant.TAGS.BOSS))
        {
            Boss_Health bossHealth = other.gameObject.GetComponent<Boss_Health>();
            bossHealth?.TakeDamage(5);
        }
    }
}
