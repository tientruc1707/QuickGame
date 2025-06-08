
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy, IMovable
{
    public EnemyData enemyData;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private ItemDropingSystem itemDropingSystem;
    private EnemyHealth health;

    private Vector3 startPosition;
    private float activeRange;
    private float speed;
    private float damage;




    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemDropingSystem = GetComponent<ItemDropingSystem>();
        health = GetComponent<EnemyHealth>();

        startPosition = transform.position;
        activeRange = enemyData.activeRange;
        speed = enemyData.speed;
        damage = enemyData.damage;
    }

    void Update()
    {
        AutoMoveSystem();
    }

    private void AutoMoveSystem()
    {

        if (transform.position.x > startPosition.x + activeRange)
        {
            MoveLeft();
        }
        else if (transform.position.x < startPosition.x - activeRange)
        {
            MoveRight();
        }
        else
        {
            if (spriteRenderer.flipX)
                MoveRight();
            else
                MoveLeft();
        }
        animator.SetBool("Move", true);
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        spriteRenderer.flipX = false;
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        spriteRenderer.flipX = true;
    }

    public void TakeDamage(float damage)
    {
        health.DeacreaseHealth(damage);
        animator.SetTrigger("Hit");
        if (health.GetCurrentHealth() <= 0)
        {
            Die();
        }
    }

    public void KnockBack(Vector3 targetPos, float force)
    {
        Vector3 direction = (transform.position - targetPos).normalized;
        transform.position += direction * force * Time.deltaTime;
    }

    public void Die()
    {

        itemDropingSystem.DropItem();
        this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.TAGS.PLAYER))
        {
            PlayerController player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
                this.KnockBack(player.transform.position, 2f);
            }
        }

    }

    public void ChangeMoveSpeed(float value)
    {
        speed = enemyData.speed;
        speed *= value;
    }

    public void FreezeObject()
    {
        animator.speed = 0;
        ChangeMoveSpeed(0);
    }

    public void UnFreezeObject()
    {
        animator.speed = 1;
        ChangeMoveSpeed(1);
    }
}
