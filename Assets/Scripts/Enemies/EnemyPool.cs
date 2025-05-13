using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyType
{
    BOAR,
    BEE
}


public class EnemyPool : MonoBehaviour
{
    [System.Serializable]
    public class EnemyTypeInfor
    {
        public EnemyType _enemyType;
        public GameObject _enemyPrefab;
        [HideInInspector] public IObjectPool<GameObject> _pool;
        public int _defaultSize;
        public int _maxSize;
    }


    [SerializeField] private List<EnemyTypeInfor> _enemyTypeList = new List<EnemyTypeInfor>();
    // Dictionary to hold the enemy pools for each enemy type
    private Dictionary<EnemyType, IObjectPool<GameObject>> _enemyPools = new Dictionary<EnemyType, IObjectPool<GameObject>>();


    private void Awake()
    {
        // Initialize the enemy pools based on the enemy type list
        foreach (var enemyType in _enemyTypeList)
        {
            var pool = new ObjectPool<GameObject>(
                () => CreateEnemy(enemyType._enemyPrefab),
                enemy => GetEnemyFromPool(enemy),
                enemy => ReturnEnemyToPool(enemy),
                enemy => DestroyEnemy(enemy),
                true,
                enemyType._defaultSize, // Default size
               enemyType._maxSize  // Maximum size
            );
            enemyType._pool = pool;
            _enemyPools.Add(enemyType._enemyType, pool);
        }
    }
    private GameObject CreateEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);

        PooledEnemy pooledComponent = enemy.GetComponent<PooledEnemy>();
        pooledComponent.SetPool(this);
        //pooledComponent.SetEnemyType(pooledComponent._enemyType);
        return enemy;
    }
    private void GetEnemyFromPool(GameObject enemy)
    {
        enemy.SetActive(true);
    }
    private void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
    private void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
    public void SpawnEnemy(EnemyType enemyType, Vector3 position, Quaternion rotation)
    {
        if (_enemyPools.ContainsKey(enemyType))
        {
            GameObject enemy = _enemyPools[enemyType].Get();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            enemy.transform.SetParent(this.transform);
            enemy.SetActive(true);
        }
        else
        {
            Debug.LogError($"Enemy type {enemyType} not found in pool.");
        }
    }

    public void ReleaseEnemy(EnemyType enemyType, GameObject enemy)
    {
        if (_enemyPools.ContainsKey(enemyType))
        {
            _enemyPools[enemyType].Release(enemy);
        }
        else
        {
            Debug.LogError($"Enemy type {enemyType} not found in pool.");
        }
    }

}

