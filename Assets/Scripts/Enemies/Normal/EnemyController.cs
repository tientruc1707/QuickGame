
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;
    private Vector3 startPosition;
    private float activeRange;
    private float speed;
    private float damage;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();

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

    public void KnockBack(Vector3 targetPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - targetPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
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

}
