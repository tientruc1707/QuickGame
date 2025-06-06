
using UnityEngine;
using UnityEngine.UI;

//CD stands for cooldown

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Slider health_Slider;
    private UIManager uiManager;
    private PlayerHealth playerHealth;


    public SkillData[] skills_CD;
    public Slider[] skills_CD_Slider;


    private void Start()
    {
        UpdateCoinText();

        uiManager = GetComponentInParent<UIManager>();
        playerHealth = GameObject.FindGameObjectWithTag(StringConstant.TAGS.PLAYER).GetComponent<PlayerHealth>();
        
        foreach (Slider slider in skills_CD_Slider)
        {
            slider.maxValue = 1;
        }

        health_Slider.maxValue = StringConstant.PLAYER_DETAIL.HEALTH;
        health_Slider.value = health_Slider.maxValue;

        EventManager.Instance.StartListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StartListening(StringConstant.EVENT.VICTORY, OnVictory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        UpdateCoinText();
        UpdateHealthSlider();
        UpdateSkillCooldown();
    }


    private void UpdateCoinText()
    {
        coinText.text = DataManager.Instance.GetCoin().ToString();
    }

    private void UpdateHealthSlider()
    {
        health_Slider.value = playerHealth.CurrentHealth();
    }

    private void UpdateSkillCooldown()
    {
        for (int i = 0; i < skills_CD_Slider.Length; ++i)
        {
            skills_CD_Slider[i].value = skills_CD[i].GetCooldownTimer();
        }
    }

    public void PauseGame()
    {
        uiManager.PauseGame();
        //UIManager.Instance.GamePause();
    }

    public void OnVictory()
    {
        uiManager.OnWinGame();
        //UIManager.Instance.LoadNextLevel();
    }

    private void OnDefeat()
    {
        uiManager.OnLoseGame();
        //UIManager.Instance.GameOver();
    }

    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StopListening(StringConstant.EVENT.VICTORY, OnVictory);
    }
}
