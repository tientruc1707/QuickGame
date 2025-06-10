
using UnityEngine;

public class PowerMode : MonoBehaviour
{
    public bool Complete { get; private set; }

    private void OnEnable()
    {
        Complete = false;
    }
    public void OnPowerMode()
    {
        Animator anim = GetComponent<Animator>();
        gameObject.SetActive(true);
        anim.SetTrigger("OnPowerMode");
    }

    //add on animation
    public void ChangeMode()
    {
        GetComponentInParent<BossColtroller>().OnPowerMode();
    }

    //add on animation
    public void SetInActive()
    {
        Complete = true;
        this.gameObject.SetActive(false);
    }
}
