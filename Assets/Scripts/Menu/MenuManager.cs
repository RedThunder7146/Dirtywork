using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TerrainTools;
using Unity.Cinemachine;
using System.Collections;
public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject volumeMenu;
    public GameObject quitMenu;
    public GameObject videoSettingsMenu;
    public GameObject startMenu;
    public GameObject difficultyMenu;
    public GameObject start;
    public GameObject controls;
    public Toggle fullscreen;
    public CinemachineCamera MenuCamera;
    public CinemachineCamera OptionsCamera;
    public CinemachineCamera PlayCamera;
    public static bool startLoading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic("MenuTheme");
        MainMenu();
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        MenuCamera.Priority = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScreen()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        volumeMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        start.SetActive(true);
        startLoading = true;
        AudioManager.instance.PlaySoundEffect("EngineStart");

        StartCoroutine("StartGameLoading");


    }
    public void OptionsMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        volumeMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 1;
        MenuCamera.Priority = 0;
        PlayCamera.Priority = 0;
    }
    public void OptionsMenuFromStart()
    {
        difficultyMenu.SetActive(false);
        mainMenu.SetActive(false);
        startMenu.SetActive(false);
        volumeMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 1;
        MenuCamera.Priority = 0;
        PlayCamera.Priority = 0;

        StartCoroutine("OptionsWait");

    }

    public void MainMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        startMenu.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        volumeMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 0;
        MenuCamera.Priority = 1;
        PlayCamera.Priority = 0;
    }
    public void MainMenuFromOptions()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        optionsMenu.SetActive(false);
        volumeMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 0;
        MenuCamera.Priority = 1;
        PlayCamera.Priority = 0;


        StartCoroutine("MenuWait");


    }

    public void QuitMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(true);
        volumeMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 0;
        MenuCamera.Priority = 1;
        PlayCamera.Priority = 0;

    }

    public void VolumeMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        volumeMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
    }
    public void VideoSettingsMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        volumeMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(true);
        controls.SetActive(false);
    }
    public void StartMenuFromMenu()
    {
        difficultyMenu.SetActive(false);
        volumeMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
        OptionsCamera.Priority = 0;
        MenuCamera.Priority = 0;
        PlayCamera.Priority = 1;

        StartCoroutine("StartMenuWait");
    }
    public void DifficultyMenu()
    {
        difficultyMenu.SetActive(true);
        startMenu.SetActive(false);
        volumeMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(false);
    }

    public void ControlMenu()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(false);
        volumeMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
        videoSettingsMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SFX()
    {
        AudioManager.instance.PlaySoundEffect("Button");
    }

    public void fullScreenMode()
    {
        if (fullscreen.isOn == true)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            print("Is fullscreened");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            print("Is not fullscreened");
        }
    }


    public IEnumerator MenuWait()
    {
        yield return new WaitForSecondsRealtime(2);
        mainMenu.SetActive(true);
    }

    public IEnumerator OptionsWait()
    {
        yield return new WaitForSecondsRealtime(2);
        optionsMenu.SetActive(true);
    }

    public IEnumerator StartMenuWait()
    {
        yield return new WaitForSecondsRealtime(2);
        startMenu.SetActive(true);
    }


    public IEnumerator StartGameLoading()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(1);
        AudioManager.instance.StopMusic("MenuTheme");
    }
}
