using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.TerrainTools;

public class SliderScripts : MonoBehaviour
{
    [Header("---- AUDIO MIXER ----")]

    [SerializeField] private AudioMixer MasterVolume;
    [Header("---- MASTER VOLUME ----")]

    [SerializeField] private Slider masterSlider;
    [SerializeField] private TextMeshProUGUI masterVol;
    [Header("---- MUSIC VOLUME ----")]

    [SerializeField] private Slider musicSlider;
    [SerializeField] private TextMeshProUGUI musicVol;
    [Header("---- SFX VOLUME ----")]

    [SerializeField] private Slider SFXSlider;
    [SerializeField] private TextMeshProUGUI SFXVol;
    [Header("---- Mute Button ----")]

    [SerializeField] private Toggle muteMusic; 

    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }
        
        

    }
    public void SetMusicVolume()
    {
        float mVolume = musicSlider.value;
        MasterVolume.SetFloat("music", Mathf.Log10(mVolume)*20);
        PlayerPrefs.SetFloat("musicVolume", mVolume);

        musicVol.text = mVolume.ToString("0%");
        muteMusic.isOn = false;
    }

    public void SetSFXVolume()
    {
        float sfxVolume = SFXSlider.value;
        MasterVolume.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

        SFXVol.text = sfxVolume.ToString("0%");
    }

    public void SetMasterVolume()
    {
        float masterVolume = masterSlider.value;
        MasterVolume.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        masterVol.text = masterVolume.ToString("0%");
    }


    public void LoadMusicVolume()
    {
        float music = PlayerPrefs.GetFloat("musicVolume");
        musicSlider.value = music;
        MasterVolume.SetFloat("music", Mathf.Log10(music) * 20);
        SetMusicVolume();

    }

    public void LoadSFXVolume()
    {
        float sfx = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = sfx;
        MasterVolume.SetFloat("SFX", Mathf.Log10(sfx) * 20);
        SetSFXVolume();
    }
    public void LoadMasterVolume()
    {
        float master = PlayerPrefs.GetFloat("masterVolume");
        masterSlider.value = master;
        MasterVolume.SetFloat("Master", Mathf.Log10(master) * 20);
        SetMasterVolume();
    }

    public void MuteMusic()
    {

        float music = PlayerPrefs.GetFloat("musicVolume");

        if(muteMusic.isOn == true)
        {
            MasterVolume.SetFloat("music", Mathf.Log10(0.0001f) * 20);
        }
        else
        {
            MasterVolume.SetFloat("music", Mathf.Log10(music) * 20);
        }

    }

}