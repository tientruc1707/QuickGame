using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private GameObject quitPanel;
    private Stack<GameObject> panelStack = new Stack<GameObject>();

    void Start()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
            panelStack.Push(mainMenuPanel);
        }
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(false);
        }
        if (quitPanel != null)
        {
            quitPanel.SetActive(false);
        }
        AudioManager.Instance.PlayBackgroundSound(StringConstant.SOUND.BACKGROUND_MUSIC);
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.YOOOOO);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panelStack.Count > 0)
        {
            GoBackToPreviousPanel();
        }
    }
    public void OnSettingButtonClicked()
    {
        SwitchToPanel(settingsPanel);
    }
    public void OnCreditsButtonClicked()
    {
        SwitchToPanel(creditsPanel);
    }
    public void OnLevelSelectButtonClicked()
    {
        SwitchToPanel(levelSelectPanel);
    }
    public void OnQuitButtonClicked()
    {
        SwitchToPanel(quitPanel);
    }
    public void OnBackButtonClicked()
    {
        GoBackToPreviousPanel();
    }
    private void SwitchToPanel(GameObject selectedPanel)
    {
        if (panelStack.Count > 0)
        {
            panelStack.Peek().SetActive(false);
        }
        selectedPanel.SetActive(true);
        panelStack.Push(selectedPanel);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void GoBackToPreviousPanel()
    {
        panelStack.Pop().SetActive(false);
        if (panelStack.Count > 0)
        {
            panelStack.Peek().SetActive(true);
        }
    }
}
