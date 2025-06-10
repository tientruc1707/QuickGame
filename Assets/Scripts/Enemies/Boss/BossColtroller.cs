
using System.Collections;
using UnityEngine;

public class BossColtroller : MonoBehaviour, IEnemy
{

    public EnemyData enemyData;
    public PlayerController player;

    private BossHealth health;
    private BossMovement movement;
    private SpriteRenderer sprite;
    private Animator animator;
    private PowerMode effectWhenStartPowerMode;


    private float deathHealth;
    private float damage;
    private float attackRange;
    private Vector3 pos;
    private bool isVulnerable;
    private bool isOnPowerMode;
    public float AttackSpeed;
    private bool attackable = true;



    private void Start()
    {
        health = GetComponent<BossHealth>();
        movement = GetComponent<BossMovement>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        effectWhenStartPowerMode = GetComponentInChildren<PowerMode>(true);


        isVulnerable = true;
        isOnPowerMode = false;
        deathHealth = enemyData.health / 3;
        damage = enemyData.damage;
        attackRange = enemyData.activeRange;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange && attackable)
        {
            StartCoroutine(Attack(1 / AttackSpeed));
        }
    }

    IEnumerator Attack(float time)
    {
        PerformAttack();
        attackable = false;
        yield return new WaitForSeconds(time);
        attackable = true;
    }
    private void PerformAttack()
    {
        switch (Random.Range(1, 4))
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
    }
    //used on animation
    public void DealDamage()
    {
        pos = this.transform.position + movement.GetDirection() * new Vector3(sprite.bounds.extents.x, 0);
        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 0.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(StringConstant.TAGS.PLAYER))
            {
                hit.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float value)
    {
        if (!isVulnerable)
        {
            return;
        }
        else
        {
            health.DecreaseHealth(value);
            animator.SetTrigger("Hurt");

            if (health.GetCurrentHealth() <= deathHealth && !isOnPowerMode)
            {
                isOnPowerMode = true;
                isVulnerable = false;
                ChangeMode();
                StartCoroutine(BackToVulnerableMode(3f));
            }

            if (health.GetCurrentHealth() <= 0)
            {
                Die();
            }
        }
    }

    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }

    //Buff when change mode
    private void ChangeMode()
    {
        ChangeAttackSpeed(2f);
        ChangeDamage(2f);
        movement.ChangeMoveSpeed(1.5f);

        //active effect when change mode 
        effectWhenStartPowerMode.OnPowerMode();
    }

    //animation when change mode
    public void OnPowerMode()
    {
        animator.SetBool("OnPowerMode", true);
        AudioManager.Instance.StopBackgroundSound();

        //if it has more than 1 boss, add a IF function this to check the boss's name
        AudioManager.Instance.PlayBackgroundSound(StringConstant.SOUND.BOSSHIDAN);
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
        Destroy(this, 3f);
    }

    public void ChangeAttackSpeed(float n)
    {
        AttackSpeed *= n;
    }

    private void ChangeDamage(float value)
    {
        damage = enemyData.damage;
        damage *= value;
    }

    IEnumerator BackToVulnerableMode(float time)
    {

        yield return new WaitForSeconds(time);

        isVulnerable = true;
    }

}
