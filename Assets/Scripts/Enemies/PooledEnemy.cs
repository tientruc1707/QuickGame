using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledEnemy : MonoBehaviour
{
    public EnemyType _enemyType;
    private EnemyPool _enemyPool;
    public void SetPool(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }
    public void ReturnToPool()
    {
        if (_enemyPool != null)
        {
            _enemyPool.ReleaseEnemy(_enemyType, gameObject);
        }
        else
        {
            Debug.LogWarning("Enemy pool is not set. Cannot return enemy to pool.");
        }
    }
}
