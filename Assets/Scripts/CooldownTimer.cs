using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer
{
    public float TimeRemaining { get; private set; }
    public float Cooldown { get; private set; }
    public bool IsRecurring { get; }
    public bool IsActive { get; private set; }
    public int TimesCounted { get; private set; }
    public float TimeElapsed => Cooldown - TimeRemaining;
    public float PercentElapsed => TimeElapsed / Cooldown;
    public bool IsCompleted => TimeRemaining <= 0;

    public delegate void TimerCompleteHandler();
    public event TimerCompleteHandler TimeToCompleteEvent;
    public CooldownTimer(float time, bool recurring = false)
    {
        Cooldown = time;
        IsRecurring = recurring;
        TimeRemaining = Cooldown;
    }
    public void Start()
    {
        if (IsActive)
        {
            TimesCounted++;
        }
        TimeRemaining = Cooldown;
        IsActive = true;
        if (TimeRemaining <= 0)
        {
            TimeToCompleteEvent?.Invoke();
        }
    }
    public void Start(float time)
    {
        Cooldown = time;
        Start();
    }
    public void Update(float timeDelta)
    {
        if (TimeRemaining > 0 && IsActive)
        {
            TimeRemaining -= timeDelta;
            if (TimeRemaining <= 0)
            {
                if (IsRecurring)
                {
                    TimeRemaining = Cooldown;
                }
                else
                {
                    IsActive = false;
                }
                TimeToCompleteEvent?.Invoke();
                TimesCounted++;
            }
        }
    }
    public void Invoke()
    {
        TimeToCompleteEvent?.Invoke();
    }
    public void Pause()
    {
        IsActive = false;
    }
    public void AddTime(float time)
    {
        TimeRemaining += time;
        Cooldown += time;
    }
}
