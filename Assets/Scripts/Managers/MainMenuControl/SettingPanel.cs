using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Toggle _sfxToggle;
    void Start()
    {
        _soundSlider.value = 1f;
        _sfxToggle.isOn = true;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     AudioManager.Instance.SetBackgroundVolume(_soundSlider.value);
    //     AudioManager.Instance.ToggleEffectVolume(_sfxToggle.isOn);
    // }
}
