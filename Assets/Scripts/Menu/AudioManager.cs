using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.TerrainTools;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public Sounds[] sounds;
    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }

        foreach (Sounds s in sounds)
        {
            s.musicSource = gameObject.AddComponent<AudioSource>();
            s.musicSource.outputAudioMixerGroup = s.musicMixer;
            s.musicSource.clip = s.clip;
            s.musicSource.volume = s.volume;
            s.musicSource.pitch = s.pitch;
            s.musicSource.loop = s.loop;

            s.SFXSource = gameObject.AddComponent<AudioSource>();
            s.SFXSource.outputAudioMixerGroup = s.SFXMixer;
            s.SFXSource.clip = s.clip;
            s.SFXSource.volume = s.volume;
            s.SFXSource.pitch = s.pitch;
            s.SFXSource.loop = s.loop;
        }

        

    }


    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }
        s.musicSource.Play();
    }

    public void PlaySoundEffect(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }
        s.SFXSource.Play();
    }

    public void StopSoundEffect(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }
        s.SFXSource.Stop();
    }
    public void StopMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }
        s.musicSource.Stop();
    }
}
