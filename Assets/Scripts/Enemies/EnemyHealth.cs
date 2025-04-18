using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
        health.MinHealth = 0;
        health.MaxHealth = StringConstant.ENEMY_DETAIL.HEALTH;
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
        gameObject.SetActive(false);
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.ENEMY_DEAD);
    }
}
