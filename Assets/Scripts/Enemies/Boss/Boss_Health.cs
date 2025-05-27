using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class Boss_Health : MonoBehaviour
{
    private int _currentLevel;
    private Animator _animator;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private PowerMode _powerMode;
    private bool _isOnPowerMode = false;
    public int _health;
    bool _isVulnerable = true;


    void Start()
    {
        _currentLevel = DataManager.Instance.GetLevel();
        _animator = GetComponent<Animator>();
        _powerMode = GetComponentInChildren<PowerMode>(true);
        _healthBar.maxValue = _health;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }
    public void TakeDamage(int damage)
    {
        if (!_isVulnerable)
        {
            return;
        }
        _health -= damage;
        if (_health <= 200 && !_isOnPowerMode)
        {
            ActivatePowerMode();
            StartCoroutine(ModeOK(6));
        }
        _animator.SetTrigger("Hurt");
        if (_health <= 0)
        {
            Die();
        }
    }
    private void UpdateHealthBar()
    {
        _healthBar.value = _health;
    }
    private void Die()
    {
        Debug.Log("Boss is dead");
        AudioManager.Instance.StopBackgroundSound();
        Destroy(gameObject);
    }
    public void ActivatePowerMode()
    {
        _powerMode.OnPowerMode();
        _isVulnerable = false;
        _isOnPowerMode = true;
    }
    public void OnPowerMode()
    {
        _animator.SetTrigger("OnPowerMode");
        AudioManager.Instance.StopBackgroundSound();
        AudioManager.Instance.PlayBackgroundSound(StringConstant.SOUND.BOSSHIDAN);
    }
    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }
    private IEnumerator ModeOK(float time)
    {
        yield return new WaitForSeconds(time);
        _isVulnerable = true;
    }
}
