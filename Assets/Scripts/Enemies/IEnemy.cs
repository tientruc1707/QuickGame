

using UnityEngine;

public interface IEnemy
{
    public void TakeDamage(float damage);
    public void KnockBack(Vector3 targetPos, float force);
}
