using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] backgroundSounds;
    public Sound[] soundEffects;
    private AudioSource backgroundAudioSource;
    private AudioSource effectSource;

    private void Start()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundAudioSource.loop = true;
        backgroundAudioSource.playOnAwake = false;
        effectSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayBackgroundSound(string name)
    {
        Sound s = System.Array.Find(backgroundSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        backgroundAudioSource.clip = s.clip;
        backgroundAudioSource.volume = s.volume;
        backgroundAudioSource.pitch = s.pitch;
        backgroundAudioSource.Play();
    }
    public void StopBackgroundSound()
    {
        backgroundAudioSource.Stop();
    }
    public void PlaySoundEffect(string name)
    {
        Sound s = System.Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        effectSource.PlayOneShot(s.clip, s.volume);
    }
    public void SetBackgroundVolume(float volume)
    {
        backgroundAudioSource.volume = Mathf.Clamp01(volume);
    }
    public void ToggleEffectVolume(bool isMuted)
    {
        if (isMuted)
        {
            effectSource.volume = 0f;
        }
        else
        {
            effectSource.volume = 1f;
        }
    }

}
