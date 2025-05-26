using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // -1 is left, 1 is right
    public void LookAtPlayer(Transform player)
    {
        if (player.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _direction = -1;
        }
        else
        {
            _spriteRenderer.flipX = false;
            _direction = 1;
        }
    }
    public int GetDirection()
    {
        return _direction;
    }

}
