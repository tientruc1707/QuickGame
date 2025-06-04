
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


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();

        startPosition = transform.position;
        activeRange = enemyData.activeRange;
        speed = enemyData.speed;
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

    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }
}
