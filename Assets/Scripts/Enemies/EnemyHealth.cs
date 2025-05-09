
using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Health _health;
    private Animator _animator;
    private EnemyPool _enemyPool;
    private ItemDropingSystem _dropSystem;
    public EnemyType enemyType;
    public EnemyDetail _enemyDetail { get; set; }




    void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();

        _enemyPool = GetComponentInParent<EnemyPool>();
        _dropSystem = GetComponentInParent<ItemDropingSystem>();

        InitEnemyDeatial();
    }

    private void InitEnemyDeatial()
    {
        if (enemyType == EnemyType.BOAR)
        {
            _enemyDetail = new EnemyDetail(
                StringConstant.ENEMY_DETAIL.BOAR.SPEED,
                StringConstant.ENEMY_DETAIL.BOAR.ATTACK_RANGE,
                StringConstant.ENEMY_DETAIL.BOAR.HEALTH,
                StringConstant.ENEMY_DETAIL.BOAR.DAMAGE,
                StringConstant.ENEMY_DETAIL.BOAR.VALUE
            );
            Debug.Log("BOAR CREATED");
        }
        else if (enemyType == EnemyType.BEE)
        {
            _enemyDetail = new EnemyDetail(
                 StringConstant.ENEMY_DETAIL.BEE.SPEED,
                 StringConstant.ENEMY_DETAIL.BEE.ATTACK_RANGE,
                 StringConstant.ENEMY_DETAIL.BEE.HEALTH,
                 StringConstant.ENEMY_DETAIL.BEE.DAMAGE,
                 StringConstant.ENEMY_DETAIL.BEE.VALUE
            );
            Debug.Log("BEE CREATED");
        }
    }
    //collision detection with player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.PLAYER))
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                if (player.GetComponent<PlayerAction>().IsAttacking)
                {
                    AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_HIT);
                    TakeDamage(StringConstant.PLAYER_DETAIL.DAMAGE);
                }
                else
                {
                    player.TakeDamage(_enemyDetail.Damage);
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        _health?.Decrement(amount);
        if (_health.CurrentHealth <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        DataManager.Instance.SetScore(DataManager.Instance.GetScore() + _enemyDetail.Value);
        //Edit Rating Here
        int random = UnityEngine.Random.Range(0, 100);
        if (random <= 100)
        {
            _dropSystem.DropItem(ItemType.COIN, transform.position);
        }
        // else if (random < 80 && random >= 50)
        // {
        //     _dropSystem.DropItem(ItemType.ARMOR, transform.position);
        // }
        // else if (random < 90 && random >= 80)
        // {
        //     _dropSystem.DropItem(ItemType.POTION, transform.position);
        // }
        // else 
        // {
        //     _dropSystem.DropItem(ItemType.WEAPON, transform.position);
        // }
        _animator.SetTrigger("Hit");
        StartCoroutine(OnDeadCoroutine());
    }

    IEnumerator OnDeadCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _enemyPool.ReturnEnemy(enemyType, gameObject);
    }
}


[System.Serializable]
public class EnemyDetail
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
