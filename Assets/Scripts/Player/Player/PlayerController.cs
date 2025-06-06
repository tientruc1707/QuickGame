
using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerAbility playerAbility;
    private Animator animator;

    private float comboTiming = 0.5f;
    private float lastHit = 0f;
    private int count = 1;
    private float damage;

    [Header("Skills")]
    private GameObject skillW;
    private GameObject skillE;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerAbility = GetComponent<PlayerAbility>();
        animator = GetComponent<Animator>();

        GameObject skillW = this.transform.GetChild(0).gameObject;
        GameObject skillE = this.transform.GetChild(1).gameObject;
        damage = playerHealth.playerData.damage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //skillList[0].ExecuteSkill(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // skillList[1].ExecuteSkill();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }

    }

    public void Attack()
    {
        if (Time.time - lastHit > comboTiming)
        {
            count = 1;
        }
        switch (count)
        {
            case 1:
                animator.SetTrigger("Attack1");
                break;
            case 2:
                animator.SetTrigger("Attack2");
                break;
            case 3:
                animator.SetTrigger("Attack3");
                break;
        }
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.PLAYER_HIT);
        lastHit = Time.time;
        count++;
    }

    public void TakeDamage(float amount)
    {
        playerHealth.DeacreaseHealth(amount);
        if (playerHealth.CurrentHealth() <= 0)
        {
            EventManager.Instance.TriggerEvent(StringConstant.EVENT.DEFEAT);
        }
    }

    public void Heal(float amount)
    {
        playerHealth.IncreaseHealth(amount);
    }
    //added on animation
    public void DealDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag(StringConstant.TAGS.ENEMY))
            {
                EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    public void ChangeDamage(float amount)
    {
        damage *= amount;
    }

    //added on animation
    public void ActiveSkill_W()
    {
        playerAbility.Active_Skill_W(skillW);
    }

    //add on animation
    public void ActiveSkill_E()
    {

    }


    public void UnfreezeAllObjects()
    {
        GameManager.Instance.UnfreezeAllObjects();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.ITEM))
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            if (item != null)
            {
                item.OnItemPickup();
                AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.ITEM_PICKUP);
                item.ReturnItemToPool();
            }
        }
    }

}
