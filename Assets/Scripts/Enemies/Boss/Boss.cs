using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // -1 is left, 1 is right
    public void LookAtPlayer(Transform player)
    {
        if (player.position.x < transform.position.x)
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

}
