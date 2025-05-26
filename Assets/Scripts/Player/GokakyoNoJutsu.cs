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
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        Debug.Log("has collider with " + other.name);
        if (other.gameObject.CompareTag(StringConstant.TAGS.ENEMY))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            EnemyController enemyPosition = other.gameObject.GetComponent<EnemyController>();
            enemyHealth?.TakeDamage(StringConstant.PLAYER_DETAIL.DAMAGE);
            enemyPosition.KnockBack(this.transform.position, 2f);
        }
        if (other.gameObject.CompareTag(StringConstant.TAGS.BOSS))
        {
            Boss_Health bossHealth = other.gameObject.GetComponent<Boss_Health>();
            bossHealth?.TakeDamage(StringConstant.PLAYER_DETAIL.DAMAGE);
            bossHealth?.KnockBack(transform.position, 2f);
        }
    }
}
