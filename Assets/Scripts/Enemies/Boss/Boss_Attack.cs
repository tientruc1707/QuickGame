
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [SerializeField] private IEnemySkill[] _skillList;

    public int damage = StringConstant.BOSS.DAMAGE;
    public int onPowerModeDamage = StringConstant.BOSS.DAMAGE * 2;

    private Vector3 pos;
    private Boss boss;
    private SpriteRenderer sprite;

    public float AttackSpeed;
    private float nextHit;

    private void Start()
    {
        boss = GetComponent<Boss>();
        sprite = GetComponent<SpriteRenderer>();
        _skillList = GetComponentsInChildren<IEnemySkill>();
    }
    private void Update()
    {
        SkillAble();
    }
    //used on animation
    public void Attack()
    {
        pos = this.transform.position + boss.GetDirection() * new Vector3(sprite.bounds.extents.x, 0);
        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 0.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(StringConstant.TAGS.PLAYER))
            {
                hit.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
        nextHit = Time.time + 1 / AttackSpeed;
    }
    //used on animation
    public void OnPowerModeAttack()
    {
        pos = this.transform.position + boss.GetDirection() * new Vector3(sprite.bounds.extents.x, 0);
        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 0.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(StringConstant.TAGS.PLAYER))
            {
                hit.GetComponent<PlayerHealth>().TakeDamage(onPowerModeDamage);
            }
        }
        nextHit = Time.time + 1 / AttackSpeed;
    }

    public void IncreseAttackSpeed(float n)
    {
        AttackSpeed *= n;
    }
    public bool Attackable()
    {
        return Time.time > nextHit;
    }
    public void SkillAble()
    {
        foreach (var skill in _skillList)
        {
            if (skill.ExecuteAble())
                skill.Excute();
        }
    }

}
