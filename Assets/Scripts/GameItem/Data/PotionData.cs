
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Items/Potion")]
public class PotionData : ItemData
{
    public float healAmount;

    public override void OnItemPickedUp()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().Heal(healAmount);
    }
}
