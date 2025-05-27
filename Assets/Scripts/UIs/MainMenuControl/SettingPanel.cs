using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Toggle _sfxToggle;
    void Start()
    {
        _soundSlider.value = 1f;
        _sfxToggle.isOn = true;
        _sfxToggle.onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(_sfxToggle);
        });
    }

    void Update()
    {
        AudioManager.Instance.SetBackgroundVolume(_soundSlider.value);
        AudioManager.Instance.ToggleEffectVolume(_sfxToggle.isOn);
    }
    void OnToggleValueChanged(Toggle toggle)
    {
        Debug.Log("SFX is " + toggle.isOn);
    }
}
