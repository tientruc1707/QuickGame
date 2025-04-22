
using UnityEngine;

public class EnemyHealth : PoolManager<EnemyHealth>
{
    private Health health;
    private int Rate ;
    void Start()
    {
        health = GetComponent<Health>();
        health.CurrentHealth = StringConstant.ENEMY_DETAIL.HEALTH;
        Rate = Random.Range(0, 100);
    }
    //collision detection with player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.PLAYER))
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(StringConstant.ENEMY_DETAIL.DAMAGE);
                //add code here to check if player is attacking
                AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_HIT);
                TakeDamage(StringConstant.PLAYER_DETAIL.DAMAGE);
            }
        }
    }
    private void TakeDamage(int amount)
    {
        health?.Decrement(amount);
        if (health.CurrentHealth <= 0)
        {

            OnDead();
        }
    }
    private void OnDead()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.ENEMY_DEAD);

        this.gameObject.SetActive(false);
    }
}
