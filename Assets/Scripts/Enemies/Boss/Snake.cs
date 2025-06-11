using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public BossMovement boss;
    private SpriteRenderer sprite;

    private void OnEnable()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    public void SummonBoss()
    {
        Animator anim = GetComponent<Animator>();
        gameObject.SetActive(true);
        GraduallyTransition(this.transform, 1);
        anim.SetTrigger("StartEffect");
        StartCoroutine(TransitionEffect(anim.GetCurrentAnimatorStateInfo(0).length * 4, this.gameObject));
    }

    public void UnSummonBoss()
    {
        Animator anim = GetComponent<Animator>();
        gameObject.SetActive(true);
        GraduallyTransition(this.transform, 1);
        anim.SetTrigger("EndEffect");
        StartCoroutine(TransitionEffect(anim.GetCurrentAnimatorStateInfo(0).length * 4, this.gameObject));
    }

    public void GraduallyTransition(Transform obj, int direction)
    {
        Vector3 destination = transform.position + new Vector3(0, 2 * sprite.bounds.extents.y, 0) * direction;
        transform.position = Vector3.Lerp(transform.position, destination, 1);
    }
    //use on Animation
    public void CreateBoss()
    {
        boss.transform.position = this.transform.position + new Vector3(0, sprite.bounds.extents.y, 0);
        Vector3 pos = boss.transform.position;
        boss.gameObject.SetActive(true);
        boss.transform.position = Vector3.MoveTowards(pos, pos + 5 * Vector3.right, 2);
        GameManager.Instance.StartLevel();
    }
    //use on Animation
    public void DenyEffect()
    {
        this.GetComponentInParent<GroundEffect>().SetInactive();
    }
    //use on Animation
    public void DenyBoss()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.VICTORY);
    }

    IEnumerator TransitionEffect(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        //down
        GraduallyTransition(obj.transform, -1);

        yield return new WaitForFixedUpdate();

        obj.SetActive(false);
    }

}
