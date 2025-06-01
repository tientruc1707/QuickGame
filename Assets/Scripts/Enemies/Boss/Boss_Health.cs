
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class Boss_Health : MonoBehaviour
{
    private int currentLevel;
    private Animator animator;
    private bool isOnPowerMode = false;
    private bool isVulnerable = true;
    private PowerMode _powerMode;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GroundEffect _effect;
    public int health;


    void Start()
    {
        currentLevel = DataManager.Instance.GetLevel();
        animator = GetComponent<Animator>();
        _powerMode = GetComponentInChildren<PowerMode>(true);
        _healthBar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (!isVulnerable)
        {
            return;
        }
        health -= damage;
        if (health <= 200 && !isOnPowerMode)
        {
            StartCoroutine(SetVulnerable(2f));
        }
        animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = health;
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
        StartCoroutine(WaitForTime(animator.GetCurrentAnimatorStateInfo(0).length));
    }
    //call to addition effect
    public void ActivatePowerMode()
    {
        _powerMode.OnPowerMode();
        isVulnerable = false;
        isOnPowerMode = true;
    }
    //enter the the effect
    public void OnPowerMode()
    {
        animator.SetTrigger("OnPowerMode");
        AudioManager.Instance.StopBackgroundSound();
        AudioManager.Instance.PlayBackgroundSound(StringConstant.SOUND.BOSSHIDAN);
    }

    public void KnockBack(Vector3 currentPos, float knockBackForce)
    {
        Vector3 direction = (transform.position - currentPos).normalized;
        transform.position += direction * knockBackForce * Time.deltaTime;
    }

    private IEnumerator SetVulnerable(float time)
    {
        ActivatePowerMode();
        yield return new WaitForSeconds(time);
        isVulnerable = true;
    }

    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        _effect.gameObject.SetActive(true);
    }

    public int GetHealth()
    {
        return health;
    }

}
