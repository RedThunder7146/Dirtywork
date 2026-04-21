using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.TerrainTools;
[System.Serializable]
public class Sounds
{
    [Header("---- AUDIO SOURCE ----")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("---- AUDIO MIXER ----")]
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup SFXMixer;

    [Header("---- AUDIO SETTINGS ----")]
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;




}