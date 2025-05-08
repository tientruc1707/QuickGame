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
                () => Instantiate(enemyType._enemyPrefab),
                obj => obj.SetActive(true),
                obj => obj.SetActive(false),
                obj => Destroy(obj),
                true,
                10,
                20
            );
            enemyType._pool = pool;
            _enemyPools.Add(enemyType._enemyType, pool);
        }
    }
    public void SpawnEnemy(EnemyType enemyType, Vector3 position, Quaternion rotation)
    {
        if (_enemyPools.ContainsKey(enemyType))
        {
            GameObject enemy = _enemyPools[enemyType].Get();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            enemy.SetActive(true);
        }
        else
        {
            Debug.LogError($"Enemy type {enemyType} not found in pool.");
        }
    }
    public void ReturnEnemy(EnemyType enemyType, GameObject enemy)
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
    private void OnDestroy()
    {
        // Clean up the pools when the object is destroyed
        foreach (var pool in _enemyPools.Values)
        {
            pool.Clear();
        }
    }
    
}

