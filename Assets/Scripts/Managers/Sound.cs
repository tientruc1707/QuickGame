using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public string _name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0.1f, 3f)]
    public float pitch = 1f;

    [HideInInspector]
    public AudioSource source;

}
