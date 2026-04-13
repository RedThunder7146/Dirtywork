using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{



    public static SanityBar instance;
    public bool sanityDrop = false;
    public float sanity = 100;
    public int mult = 1;
    public Slider sanitySlider;
    float timer = 0;
    InputAction interactAction;


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

        }


        if (sanityDrop == true)
        {
            SanitySpeedUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "houseTrig")
        {
            sanityDrop = true;
        }
    }

    public void SanityDropSystem()
    {
        sanity = sanity - Time.deltaTime*1*mult;
        sanitySlider.value = sanity;
    }

    public void SanityRiseSystem()
    {
        sanity = sanity + Time.deltaTime*5;
    }


    public void SanitySpeedUp()
    {
        

        timer = timer + Time.deltaTime;
        float timerRounded = Mathf.RoundToInt(timer);
        print (timerRounded);
        int timerMult= Mathf.FloorToInt(timerRounded/60);
        mult=1 + timerMult;

        
    }
}
