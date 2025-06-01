using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffect : MonoBehaviour
{
    private Snake snake;
    private Animator anim;
    public Boss_Health boss;

    private void OnEnable()
    {
        snake = GetComponentInChildren<Snake>(true);
        anim = GetComponent<Animator>();
        anim.SetTrigger("Active");
    }
    public void Summon()
    {
        if (boss.GetHealth() != 0)
            snake.SummonBoss();
        else
            snake.UnSummonBoss();
    }
    public void SetInactive()
    {
        this.gameObject.SetActive(false);
    }
}
