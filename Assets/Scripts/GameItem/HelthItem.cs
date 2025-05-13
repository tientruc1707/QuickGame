using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthItem : MonoBehaviour, IIItem
{
    [SerializeField] private PlayerHealth _playerHealth;
    private int HealthValue => 20;
    public void OnItemPickup()
    {
        if (_playerHealth.CurrentHealth < StringConstant.PLAYER_DETAIL.HEALTH)
        {
            _playerHealth.Heal(HealthValue);
            //AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_HEAL);
        }
    }
}
