
using System;
using System.Collections;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public Skill_Q_Data skill_Q_Data;
    public Skill_W_Data skill_W_Data;
    //public Skill_E_Data skill_E_Data;


    public void Execute_Skill_Q()
    {
        if (skill_Q_Data.GetCooldownTimer() <= 0)
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Pos.z = 0;
            this.gameObject.transform.position = Pos;
            skill_Q_Data.UpdateCooldown();
        }
    }

    public void Execute_Skill_W(GameObject player)
    {
        if (skill_W_Data.GetCooldownTimer() <= 0)
        {
            player.GetComponent<Animator>().SetTrigger("Skill W");
            //should edit here if it has player choosen 
            AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GOKAKYO);

            skill_W_Data.UpdateCooldown();
        }
    }

    public void Execute_Skill_E(GameObject skillObject)
    {

    }

    public void ActiveDamagableSkill(GameObject skillObject)
    {
        skillObject.SetActive(true);
        Animator anim = skillObject.GetComponent<Animator>();
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
                //EnemyController enemy = hit.GetComponent<EnemyController>();
                EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage * Time.deltaTime);
            }
        }
    }

    public void Active_Skill_W(GameObject obj)
    {
        ActiveDamagableSkill(obj);
        StartCoroutine(ApplyContinuousDamage(obj, skill_W_Data.baseDamage));
    }

    IEnumerator ApplyContinuousDamage(GameObject obj, float damage)
    {
        ApplyDamage(obj, damage);
        yield return new WaitForSeconds(1f);
    }

    public void ActiveSkill_E()
    {

    }
}
