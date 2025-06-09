
using UnityEngine;

public class CameraColtroller : MonoBehaviour
{
    public Transform player;
    private BossMovement boss;
    public Vector3 offset = new(0, 5, -10);
    public float smoothSpeed = 0.125f;
    public GameObject MapBounds;

    private void Start()
    {
        boss = FindObjectOfType<BossMovement>(true);
        if (boss != null)
        {
            FocusOn(boss.gameObject);
        }
        else
        {
            return;
        }
    }

    void LateUpdate()
    {
        if (Time.time > 7f)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y, -10);
        }
        //add max position
    }

    private void FocusOn(GameObject obj)
    {
        Vector3 targetPos = obj.transform.position + offset;
        Vector3 moving = Vector3.Lerp(transform.position, targetPos, 2f);
        transform.position = moving;

    }
}
