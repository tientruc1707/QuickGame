

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

    private GameObject skillQ;
    private GameObject skillW;



    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerAbility = GetComponent<PlayerAbility>();
        animator = GetComponent<Animator>();

        skillQ = this.transform.GetChild(0).gameObject;
        skillW = this.transform.GetChild(1).gameObject;
        damage = playerHealth.playerData.damage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAbility.Execute_Skill_Q();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAbility.Execute_Skill_W();
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
                EnemyController enemy = hit.GetComponent<EnemyController>();
                enemy.TakeDamage(damage);
                enemy.KnockBack(transform.position, 2f);
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

    //add on animation
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
