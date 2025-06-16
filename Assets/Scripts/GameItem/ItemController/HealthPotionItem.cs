
using UnityEngine;

public class HealthPotion : MonoBehaviour, IItem
{
    public HealthPotionData potion;
    public void OnItemPickup()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().Heal(potion.healAmount);
    }

    public void ReturnItemToPool()
    {
        this.gameObject.SetActive(false);
    }
}
