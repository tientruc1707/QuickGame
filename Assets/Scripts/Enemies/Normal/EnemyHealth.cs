
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator _animator;
    private ItemDropingSystem _dropSystem;
    public EnemyData enemyData;
    private float health;

    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _dropSystem = GetComponent<ItemDropingSystem>();
        health = enemyData.health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        _animator.SetTrigger("Hit");
        if (health <= 0)
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
