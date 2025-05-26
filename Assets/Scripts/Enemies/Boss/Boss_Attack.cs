using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public int damage = StringConstant.BOSS.DAMAGE;
    public int onPowerModeDamage = StringConstant.BOSS.DAMAGE * 2;
    public Vector3 attackOffdet;
    public int attackRange = StringConstant.BOSS.ATTACK_RANGE;
    public void Attack()
    {

    }
    public void OnPowerModeAttack()
    {

    }
}
