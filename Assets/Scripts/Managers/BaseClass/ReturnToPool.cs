using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public ObjectPool pool;
    
    void OnDisable()
    {
        pool.AddToPool(this.gameObject);
    }
}
