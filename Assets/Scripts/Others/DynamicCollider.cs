using UnityEngine;

public class DynamicCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (spriteRenderer.sprite != null)
        {
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            boxCollider.size = spriteSize;
            boxCollider.offset = spriteRenderer.sprite.bounds.center;
        }
    }
}