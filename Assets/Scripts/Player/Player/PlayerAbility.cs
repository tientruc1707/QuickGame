
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    private PlayerMovement playerMovement;
    public Skill_Q_Data skill_Q_Data;
    public Skill_W_Data skill_W_Data;
    //public Skill_E_Data skill_E_Data;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
            GameManager.Instance.FreezeAllObjects(this.GameObject());
            playerMovement.ChangeMoveSpeed(0);
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
        obj.transform.position = transform.position + new Vector3(sprite.bounds.extents.x * playerMovement.direction, sprite.bounds.extents.y);
        obj.GetComponent<SpriteRenderer>().flipX = sprite.flipX;
        ActiveDamagableSkill(obj);
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

}
