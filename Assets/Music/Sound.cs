using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
[CreateAssetMenu(fileName = "Sound", menuName = "ScriptableObjects/Sound",order =1)]
public class Sound : ScriptableObject
{
    [SerializeField] public string soundName;
    [SerializeField] public string author;
    [SerializeField] public AudioClip audioClip;
    [SerializeField] public AudioMixerGroup audioMixerGroup;
    [SerializeField] [Range (0f, 1f)] public float volume=1;
    [SerializeField] [Range (0.1f, 3f)] public float pitch=1;
}
