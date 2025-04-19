using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHECKPOINT_REACHED);
            Debug.Log("Checkpoint Reached!");
        }
    }
}
