using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour, IMovable
{
    public EnemyData enemyData;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GameObject player;

    public bool Moveable { get; set; }
    private int direction = 1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(StringConstant.TAGS.PLAYER);
        StartCoroutine(HoldSpeedASecond(3f));

    }

    public IEnumerator HoldSpeedASecond(float time)
    {
        Moveable = false;
        ChangeMoveSpeed(0);
        yield return new WaitForSecondsRealtime(time);
        ChangeMoveSpeed(1);
        Moveable = true;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Move", speed);
        if (Moveable)
        {
            ChasePlayer();
        }

    }

    public int GetDirection()
    {
        return direction;
    }

    private void ChasePlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
            direction = -1;
        }
        else
        {
            spriteRenderer.flipX = false;
            direction = 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (ObstacleDetection())
        {
            rb.velocity = new Vector2(rb.velocity.x + direction, 6f);
            animator.SetTrigger("Jump");
        }
    }

    private bool ObstacleDetection()
    {
        Color color = Color.red;
        float rayLenght = 3f;
        LayerMask layer = LayerMask.GetMask("Ground");
        Vector3 root = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(root, Vector3.right * direction, rayLenght, layer);

        if (hit.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
        Debug.DrawRay(root, direction * rayLenght * Vector3.right, color);
        return hit.collider != null;
    }

    public void ChangeMoveSpeed(float value)
    {
        speed = enemyData.speed;
        speed *= value;
        Debug.Log($"Speed now is {speed}");
    }

    public void FreezeObject()
    {
        ChangeMoveSpeed(0);
        animator.speed = 0;
    }

    public void UnFreezeObject()
    {
        ChangeMoveSpeed(1);
        animator.speed = 1;
    }
}
