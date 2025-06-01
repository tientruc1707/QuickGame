
using System;
using System.Collections;
using UnityEngine;

public enum EnemyType
{
    BOAR,
    BEE
}
public class EnemyHealth : MonoBehaviour
{
    private int _health;
    private Animator _animator;
    private ItemDropingSystem _dropSystem;
    public EnemyDetail _enemyDetail { get; set; }
    public EnemyType _enemyType;



    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _dropSystem = GetComponent<ItemDropingSystem>();
        InitEnemyDeatial();
        _health = _enemyDetail.Health;
    }

    private void InitEnemyDeatial()
    {
        if (_enemyType == EnemyType.BOAR)
        {
            _enemyDetail = new EnemyDetail(
                StringConstant.ENEMY_DETAIL.BOAR.SPEED,
                StringConstant.ENEMY_DETAIL.BOAR.ATTACK_RANGE,
                StringConstant.ENEMY_DETAIL.BOAR.HEALTH,
                StringConstant.ENEMY_DETAIL.BOAR.DAMAGE,
                StringConstant.ENEMY_DETAIL.BOAR.VALUE
            );
        }
        else if (_enemyType == EnemyType.BEE)
        {
            _enemyDetail = new EnemyDetail(
                 StringConstant.ENEMY_DETAIL.BEE.SPEED,
                 StringConstant.ENEMY_DETAIL.BEE.ATTACK_RANGE,
                 StringConstant.ENEMY_DETAIL.BEE.HEALTH,
                 StringConstant.ENEMY_DETAIL.BEE.DAMAGE,
                 StringConstant.ENEMY_DETAIL.BEE.VALUE
            );
        }
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _animator.SetTrigger("Hit");
        if (_health <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        _dropSystem.DropItem();
        _animator.SetTrigger("Hit");
        this.gameObject.SetActive(false);
    }
}


[System.Serializable]
public struct EnemyDetail
{
    public int Speed { get; set; }
    public int MovingRange { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Value { get; set; }
    public EnemyDetail(int speed, int movingRange, int health, int damage, int value)
    {
        Speed = speed;
        MovingRange = movingRange;
        Health = health;
        Damage = damage;
        Value = value;
    }
}
