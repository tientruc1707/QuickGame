using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectingPanel : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    private void Start()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Capture the current value of i
            _levelButtons[i].onClick.AddListener(() => OnLevelButtonClicked(levelIndex));
            if (levelIndex > DataManager.Instance.GetLevel())
            {
                _levelButtons[i].interactable = false;
            }
            else
            {
                _levelButtons[i].interactable = true;
            }
        }
    }
    private void OnLevelButtonClicked(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
        //UIManager.Instance.InitializePanels();
        DataManager.Instance.SetLevel(levelIndex);
    }
    private void OnDestroy()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            int levelIndex = i;
            _levelButtons[i].onClick.RemoveListener(() => OnLevelButtonClicked(levelIndex));
        }
    }
    void OnDrawGizmosSelected()
    {
        _levelButtons = GetComponentsInChildren<Button>();
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].name = "Level" + (i + 1);
            _levelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }
}
