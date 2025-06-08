
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    private float health;

    void OnEnable()
    {
        health = enemyData.health;
    }

    public void DeacreaseHealth(float amount)
    {
        health -= amount;
    }

    public float GetCurrentHealth()
    {
        return health;
    }
}
