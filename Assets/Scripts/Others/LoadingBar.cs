
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Slider _loadingBar;
    //[SerializeField] private string _sceneName;
    AsyncOperation _asyncOperation;
    void Start()
    {
        _loadingBar = GetComponent<Slider>();
        _asyncOperation = SceneManager.LoadSceneAsync(StringConstant.SCENES.MAIN_MENU);
    }

    // Update is called once per frame
    void Update()
    {
        _loadingBar.value = Mathf.Clamp01(_asyncOperation.progress / 0.9f);
        if (_asyncOperation.progress >= 0.9f)
        {
            EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHANGE_SCENE);
            _loadingBar.value = 1f;
            _asyncOperation.allowSceneActivation = true;
        }
    }
}
