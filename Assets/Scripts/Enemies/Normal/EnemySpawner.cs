using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _spawnZone;
    private SpriteRenderer _sprite;
    [SerializeField] private GameObject _eBoar;
    [SerializeField] private GameObject _eBee;

    void OnEnable()
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
            int type = Random.Range(0, 2);
            int j = (int)_spawnZone.transform.position.y;
            Vector3 spawnPosition = new(i, j, 0);
            switch (type)
            {
                case 0:
                    GenerateEnemy(_eBoar, spawnPosition);
                    break;
                case 1:
                    GenerateEnemy(_eBee, spawnPosition);
                    break;
                default:
                    break;
            }
        }
    }
    private void GenerateEnemy(GameObject obj, Vector3 pos)
    {
        PoolManager.Instance.GetFromPool(obj);
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.identity;
    }
}
