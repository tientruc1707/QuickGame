using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffect : MonoBehaviour
{
    private Snake snake;
    private Animator anim;
    public BossHealth boss;

    private void OnEnable()
    {
        snake = GetComponentInChildren<Snake>(true);
        anim = GetComponent<Animator>();
        anim.SetTrigger("Active");
    }

    //added on animation and called when boss die
    public void Summon()
    {
        if (boss.GetCurrentHealth() > 0)
            snake.SummonBoss();
        else
            snake.UnSummonBoss();
    }

    public void SetInactive()
    {
        this.gameObject.SetActive(false);
    }
}
