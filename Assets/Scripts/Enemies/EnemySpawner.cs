using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    private GameObject _spawnZone;
    private SpriteRenderer _sprite;

    void Start()
    {
        _spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
        _sprite = _spawnZone.GetComponent<SpriteRenderer>();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int x = (int)_spawnZone.transform.position.x;
        int y = (int)_spawnZone.transform.position.y;
        int value = (int)_sprite.bounds.size.x / 2;

        for (int i = x - value; i < x + value; i += 6)
        {
            int type = Random.Range(0, _enemyPool.ListSize());
            int j = (int)_spawnZone.transform.position.y;
            Vector3 spawnPosition = new(i, j, 0);
            switch (type)
            {
                case 0:
                    _enemyPool.SpawnEnemy(EnemyType.BOAR, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    _enemyPool.SpawnEnemy(EnemyType.BEE, spawnPosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
            Debug.Log("Spawn enemy type: " + type + " at position: " + spawnPosition);
        }
    }
}
