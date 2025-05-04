using UnityEngine;

public abstract class ISkill : MonoBehaviour
{
    public abstract void ExecuteSkill();
    public abstract float GetCoolDownTime();
}

enum SkillType
{
    Dash,
    KatonGokakyoNoJutsu,
    Skill2,
    Skill3,
    Ultimate
}
