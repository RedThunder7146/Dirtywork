using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{



    public static SanityBar instance;
    public float musicPower;
    public Slider musicPowerSlider;
    public bool sanityDrop = false;
    public float sanity = 100;
    public int mult = 1;
    public Slider sanitySlider;
    public float timer = 0;
    public float halluMult = 1;
    public bool sanityRise;
    InputAction interactAction;
    public Transform teleportPos;


    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        sanitySlider.value = sanity;
        if (sanityDrop == true)
        {
            SanityDropSystem();
        }

        if (Input.GetKey(KeyCode.E))
        {
            SanityRiseSystem();
            sanityRise = true;
        }
        else
        {
            sanityRise = false;
        }


        if (sanityDrop == true)
        {
            SanitySpeedUp();
        }

        MusicPower();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "houseTrig")
        {
            sanityDrop = true;
            transform.position = teleportPos.transform.position;

            print("Trigger");
        }
    }

    public void SanityDropSystem()
    {
        if (sanity > 0)
        {
            sanity = sanity - Time.deltaTime * 1 * mult * halluMult;
            sanitySlider.value = sanity;

        }

        else
        {
            SceneManager.LoadScene(0);
        }

    }

    public void SanityRiseSystem()
    {
        if (sanity < 100 && musicPower > 0)
        {
            sanity = sanity + Time.deltaTime * 5;
            sanityRise = true;
        }
    }


    public void SanitySpeedUp()
    {
        

        timer = timer + Time.deltaTime;
        float timerRounded = Mathf.RoundToInt(timer);
        int timerMult= Mathf.FloorToInt(timerRounded/60);
        mult=1 + timerMult;

        
    }

    public void MusicPower()
    {
        if(sanityRise == true)
        {
            musicPower = musicPower - Time.deltaTime * 0.2f;
            musicPowerSlider.value = musicPower;
        }
    }
}
