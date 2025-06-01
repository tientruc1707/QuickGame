using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMode : MonoBehaviour
{
    public void OnPowerMode()
    {
        Animator anim = GetComponent<Animator>();
        gameObject.SetActive(true);
        anim.SetTrigger("OnPowerMode");
    }

    public void ChangeMode()
    {
        GetComponentInParent<Boss_Health>().OnPowerMode();
    }

    public void SetInActive()
    {
        this.gameObject.SetActive(false);
    }
}
