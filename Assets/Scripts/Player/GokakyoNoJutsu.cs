using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GokakyoNoJutsu : ISkill
{
    [SerializeField] private Animator _animator;
    private float _cooldown = 5f;
    private float _lastExecution = 0f;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        GetCoolDownTime();
        if (Time.time - _lastExecution >= _animator.GetCurrentAnimatorStateInfo(0).length)
        {
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
            this.gameObject.SetActive(true);
            _lastExecution = Time.time;
        }
    }
    public void DisableGokakyoNoJutsu()
    {
        this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.ENEMY))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            EnemyController enemyPosition = other.gameObject.GetComponent<EnemyController>();
            enemyHealth?.TakeDamage(StringConstant.PLAYER_DETAIL.DAMAGE);
            enemyPosition.KnockBack(enemyPosition.transform.position, 2f);
        }
    }
}
