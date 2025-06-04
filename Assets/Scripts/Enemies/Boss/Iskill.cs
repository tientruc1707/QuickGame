
using Unity.VisualScripting;

public interface IEnemySkill
{
    void Excute();
    float Cooldown { get; set; }
    bool ExecuteAble();
    float LastExecution();
}
