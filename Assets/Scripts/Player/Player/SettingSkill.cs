
using UnityEngine;

public class SettingSkill : MonoBehaviour
{
    private PlayerAbility _ability;
    private Animator animator;
    private float skillDamage;
    private float timeSincelastCheck = 0;
    private float timeStep = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _ability = GetComponentInParent<PlayerAbility>();
        animator = GetComponent<Animator>();
        if (gameObject.name.Equals("Skill W"))
        {
            skillDamage = _ability.skill_W_Data.baseDamage;
        }
        //else when have more skill
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(StringConstant.TAGS.ENEMY))
        {
            IEnemy enemy = other.GetComponent<IEnemy>();
            enemy.KnockBack(transform.position, 2f);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        timeSincelastCheck += Time.deltaTime;
        if (other.CompareTag(StringConstant.TAGS.ENEMY) && timeSincelastCheck >= timeStep)
        {
            IEnemy enemy = other.GetComponent<IEnemy>();
            enemy.TakeDamage(skillDamage);
            timeSincelastCheck = 0;
        }
    }

    //added on animation
    //each animation has a function to cancel it
    public void InActiveSkill_W()
    {
        animator.ResetTrigger("ActiveSkill");
        //GetComponentInParent<Animator>().ResetTrigger("Skill W");
        gameObject.SetActive(false);
    }

}
