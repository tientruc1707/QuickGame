using System.Collections.Generic;
using UnityEngine;

public class DynamicCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            return;
        }
        polygonCollider = GetComponent<PolygonCollider2D>();
        if (polygonCollider != null)
        {
            return;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (boxCollider != null && spriteRenderer != null)
        {
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            boxCollider.size = spriteSize;
            boxCollider.offset = spriteRenderer.sprite.bounds.center;
        }
    }

    public void UpdateWithPolygonCollider()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        Sprite currentSprite = spriteRenderer.sprite;
        List<List<Vector2>> paths = new List<List<Vector2>>();

        int pointCount = currentSprite.GetPhysicsShapeCount();

        for (int i = 0; i < pointCount; i++)
        {
            List<Vector2> pathPoint = new List<Vector2>();
            currentSprite.GetPhysicsShape(i, pathPoint);
            if (spriteRenderer.flipX)
            {
                for (int j = 0; j < pathPoint.Count; j++)
                {
                    pathPoint[j] = new Vector2(-pathPoint[j].x, pathPoint[j].y);
                }
            }
            paths.Add(pathPoint);
        }
        polygonCollider.pathCount = paths.Count;
        for (int i = 0; i < paths.Count; i++)
        {
            polygonCollider.SetPath(i, paths[i].ToArray());
        }
    }

    public void SetInactiveObject()
    {
        this.GetComponent<Animator>().ResetTrigger("ActiveSkill");
        this.gameObject.SetActive(false);
    }
}