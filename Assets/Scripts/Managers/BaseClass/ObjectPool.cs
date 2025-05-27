using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Stack<GameObject> _myPool = new Stack<GameObject>();
    private GameObject _baseObject;
    private GameObject _tmp;
    private ReturnToPool _returnToPool;


    public ObjectPool(GameObject _baseObj)
    {
        this._baseObject = _baseObj;
    }

    public GameObject Get()
    {
        if (_myPool.Count > 0)
        {
            _tmp = _myPool.Pop();
            _tmp.SetActive(true);
            return _tmp;
        }
        _tmp = GameObject.Instantiate(_baseObject);
        _returnToPool = _tmp.AddComponent<ReturnToPool>();
        _returnToPool.pool = this;
        return _tmp;
    }

    public void AddToPool(GameObject gameObject)
    {
        _myPool.Push(gameObject);
    }
}
