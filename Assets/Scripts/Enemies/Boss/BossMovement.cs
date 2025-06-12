using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour, IMovable
{
    public EnemyData enemyData;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GameObject player;


    private int direction = 1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(StringConstant.TAGS.PLAYER);
        StartCoroutine(SetUpSpeed(3f));
    }

    IEnumerator SetUpSpeed(float time)
    {
        ChangeMoveSpeed(0);
        yield return new WaitForSecondsRealtime(time);
        ChangeMoveSpeed(1);
    }

    private void Update()
    {
        if (speed > 0)
        {
            animator.SetFloat("Move", speed);
            LookAtPlayer();
            ChasePlayer();
        }
    }

    // -1 is left, 1 is right
    public void LookAtPlayer()
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
    }

    public int GetDirection()
    {
        return direction;
    }

    private void ChasePlayer()
    {
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
