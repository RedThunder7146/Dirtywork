using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TerrainTools;
using Unity.Cinemachine;
using System.Collections;
public class ButtonScript : MonoBehaviour
{


    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    

    public void PlayCalmingMusic()
    {
        AudioManager.instance.PlayMusic("CalmMusic");
    }

    public void StopCalmingMusic()
    {
        AudioManager.instance.StopMusic("CalmMusic");
    }


    
    public void SFX()
    {
        AudioManager.instance.PlaySoundEffect("Button");
    }

    
}
