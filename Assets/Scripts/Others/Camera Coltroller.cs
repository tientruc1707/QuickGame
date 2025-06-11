
using System.Collections;
using UnityEngine;

public class CameraColtroller : MonoBehaviour
{
    public Transform player;
    private BossMovement boss;
    public Vector3 offset = new(0, 5, -10);
    private GameObject TargetToFollow;

    private void Start()
    {
        boss = FindObjectOfType<BossMovement>(true);
        if (boss != null)
        {
            TargetToFollow = boss.gameObject;
            StartCoroutine(BackToPlayer(7f));
        }
        else
        {
            TargetToFollow = player.gameObject;
        }
    }

    void LateUpdate()
    {
        FocusOn(TargetToFollow);
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

    IEnumerator BackToPlayer(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        TargetToFollow = player.gameObject;
    }
}
