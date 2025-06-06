
using UnityEngine;


[CreateAssetMenu(fileName = "New Player", menuName = "Characters/Player")]
public class PlayerData : ScriptableObject
{
    public float health;
    public float damage;
    public float speed;
    public float jumpForce;

}
