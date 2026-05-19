using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{


    public int soundRND;
    public int rndSound;
    public float soundTimer;
    public string sound;
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
    public CharacterController characterController;
    public GameObject fadeToBlack;


    bool noreplay = false;
    bool replay = true;


    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        soundRND = Random.Range(0, 30);
        rndSound = Random.Range(0, 4);
        AudioManager.instance.PlaySoundEffect("Breathing");


    }

    void Update()
    {
        

        if (sanityDrop == true)
        {
            soundTimer = soundTimer + Time.deltaTime;
        }

        if (rndSound == 0)
        {
            sound = "TerrifyingWind";
        }

        if (rndSound == 1)
        {
            sound = "EerieWind";
        }

        if (rndSound == 2)
        {
            sound = "EerieWind2";
        }

        if (rndSound == 3)
        {
            sound = "Knocking";
        }

        if (rndSound == 4)
        {
            sound = "SneakOnWood";
        }

        if (soundTimer >= soundRND)
        {
            AudioManager.instance.PlaySoundEffect(sound);
            soundRND = Random.Range(0, 30);
            print(soundRND);
            print(rndSound);

            rndSound = Random.Range(0, 4);
            soundTimer = 0;

            
        }

        

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



        if (sanityRise == true&& musicPower >0)
        {
            if (noreplay == false)
            {
                AudioManager.instance.PlayMusic("CalmMusic");
                noreplay = true;
            }
        }

        if (sanityRise == false)
        {
            AudioManager.instance.StopMusic("CalmMusic");
            noreplay = false;
        }

        if (sanityDrop == true)
        {
            if(replay == true)
            {
                AudioManager.instance.PlayMusic("HorrorAmbience");
                replay = false;
            }
        }


        Color newColor = Color.black;
        newColor.a = sanity / -50 + 1;
        fadeToBlack.GetComponent<Image>().color = newColor;
    
        AudioManager.instance.sounds[4].SFXSource.volume = sanity / -50 + 1+0.1f;
        

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
            characterController.enabled = false;
            characterController.transform.position = teleportPos.transform.position;
            characterController.enabled = true;
            print("Trigger");
        }
    }

    public void SanityDropSystem()
    {
        if (sanity > 0)
        {


            
            sanity = sanity - Time.deltaTime * 1 * halluMult * (mult * 0.5f);
            sanitySlider.value = sanity;

        }

        else
        {
            Die();
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
            musicPower = musicPower - Time.deltaTime * 0.5f;
            musicPowerSlider.value = musicPower;
        }
    }

    public void Die()
    {
        if (sanity <= 0)
        {
            AudioManager.instance.StopSoundEffect("Breathing");
            AudioManager.instance.StopMusic("HorrorAmbience");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            sanityDrop = false;
            AudioManager.instance.StopMusic("CalmMusic");
            SceneManager.LoadScene(0);
            
        }
    }


}
