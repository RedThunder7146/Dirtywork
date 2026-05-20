using UnityEngine;
using UnityEngine.InputSystem;

public class LightChange : MonoBehaviour
{
    public GameObject ultra_Violet_Light;
    public GameObject torch;
    InputAction torchSwitch;
    bool uvOn = true;
    bool torchOn = false;
    float count = 0;

    private void Start()
    {
        torchSwitch = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Switch");


            
            if (uvOn == true)
            {
                print("Torch");
                ultra_Violet_Light.SetActive(false);
                torch.SetActive(true);
                uvOn = false;
                torchOn = true;
                count = 0;
            }

            else
            {
                print("UV");
                ultra_Violet_Light.SetActive(true);
                torch.SetActive(false);
                uvOn = true;
                torchOn = false;
                count = 0;
            }

            

        }

       




    }
}
