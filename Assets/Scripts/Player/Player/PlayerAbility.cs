
using System;
using System.Collections;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    public Skill_Q_Data skill_Q_Data;
    public Skill_W_Data skill_W_Data;
    //public Skill_E_Data skill_E_Data;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        skill_Q_Data.ResetCooldown();
        skill_W_Data.ResetCooldown();
    }

    public void Execute_Skill_Q()
    {
        if (skill_Q_Data.GetCooldownTimer() <= 0)
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Pos.z = 0;
            animator.SetTrigger("Skill Q");
            this.gameObject.transform.position = Pos;
            skill_Q_Data.UpdateCooldown();
        }
    }

    public void Execute_Skill_W()
    {
        if (skill_W_Data.GetCooldownTimer() <= 0)
        {
            playerMovement.ChangeMoveSpeed(0);
            GameManager.Instance.FreezeAllObjects(this.gameObject);
            animator.SetTrigger("Skill W");
            //should edit here if it has player choosen 
            AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GOKAKYO);

            skill_W_Data.UpdateCooldown();
        }
    }

    public void Execute_Skill_E(GameObject skillObject)
    {

    }

    public void Active_Skill_W(GameObject obj)
    {
        ActiveDamagableSkill(obj);
        StartCoroutine(ApplyContinuousDamage(obj, skill_W_Data.baseDamage));
    }

    public void Active_Skill_E()
    {

    }

    public void ActiveDamagableSkill(GameObject skillObject)
    {
        Animator anim = skillObject.GetComponent<Animator>();
        skillObject.SetActive(true);
        anim.SetTrigger("ActiveSkill");
    }

    private void ApplyDamage(GameObject obj, float damage)
    {
        Collider2D collider = obj.GetComponent<Collider2D>();

        Collider2D[] hits = Physics2D.OverlapBoxAll(obj.transform.position, collider.bounds.size, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag(StringConstant.TAGS.ENEMY))
            {
                EnemyController enemy = hit.GetComponent<EnemyController>();
                enemy.TakeDamage(damage);
            }
        }
    }

    IEnumerator ApplyContinuousDamage(GameObject obj, float damage)
    {
        while (true)
        {
            ApplyDamage(obj, damage);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
