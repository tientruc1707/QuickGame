
using System;
using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public float nextExecution;
    // public float manaCost;

    public virtual float GetCooldownTimer()
    {
        return Math.Clamp(nextExecution - Time.time, 0, cooldown) / cooldown;
    }

    public virtual void UpdateCooldown()
    {
        nextExecution = Time.time + cooldown;
    }

    public void ResetCooldown()
    {
        nextExecution = 0f;
    }
    
}
