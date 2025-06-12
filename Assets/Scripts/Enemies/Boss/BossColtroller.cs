
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossColtroller : MonoBehaviour, IEnemy
{

    public EnemyData enemyData;
    public PlayerController player;

    private BossHealth health;
    private BossMovement movement;
    private SpriteRenderer sprite;
    private Animator animator;
    public GroundEffect groundEffect;

    private float deathHealth;
    private float damage;
    private float attackRange;
    private Vector3 pos;
    private bool isVulnerable = true;
    private bool isOnPowerMode = false;
    public float AttackSpeed;
    private bool attackable = true;

    public GameObject PowerMode;

    private void Start()
    {
        health = GetComponent<BossHealth>();
        movement = GetComponent<BossMovement>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        deathHealth = enemyData.health / 2;
        damage = enemyData.damage;
        attackRange = enemyData.activeRange;
    }


    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange && attackable)
        {
            StartCoroutine(Attack(1 / AttackSpeed));
        }

        if (health.GetCurrentHealth() <= deathHealth && !isOnPowerMode)
        {
            movement.Moveable = false;
            movement.ChangeMoveSpeed(0);
            isOnPowerMode = true;
            isVulnerable = false;
            GameManager.Instance.FreezeAllObjects(this.gameObject);
            OnPowerMode();
        }

        if (health.GetCurrentHealth() <= 0)
        {
            Die();
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

        health.DecreaseHealth(value);
        animator.SetTrigger("Hurt");
    }

    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }

    //animation when change mode
    public void OnPowerMode()
    {
        PowerMode.SetActive(true);
        PowerMode.GetComponent<Animator>().SetTrigger("OnPowerMode");

        animator.SetBool("OnPowerMode", true);
        AudioManager.Instance.StopBackgroundSound();

        //if it has more than 1 boss, add a IF function this to check the boss's name
        AudioManager.Instance.PlayBackgroundSound(StringConstant.SOUND.BOSSHIDAN);
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        groundEffect.gameObject.SetActive(true);
        groundEffect.Summon();
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

    //added on animation
    public void PowerModeDone()
    {
        ChangeAttackSpeed(2f);
        ChangeDamage(2f);
        movement.ChangeMoveSpeed(1.5f);
        movement.Moveable = true;
        health.Regen();

        Debug.Log(movement.speed + " " + damage);
        PowerMode.SetActive(false);
        GameManager.Instance.UnfreezeAllObjects();
        Debug.Log("UnfreezeOK!");
        isVulnerable = true;
    }

}
