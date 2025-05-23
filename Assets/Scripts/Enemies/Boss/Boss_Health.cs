using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    private int _currentLevel;
    private Animator _animator;
    public int _health;
    bool _isVulnerable = true;
    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = DataManager.Instance.GetLevel();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        if (!_isVulnerable)
        {
            return;
        }
        _health -= damage;
        if (_health <= 200)
        {
            _isVulnerable = false;
            _animator.SetBool("OnPowerMode", true);
        }
        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle boss death
        Debug.Log("Boss is dead");
        // You can add more logic here, like playing an animation or dropping loot
        Destroy(gameObject);
    }
}
