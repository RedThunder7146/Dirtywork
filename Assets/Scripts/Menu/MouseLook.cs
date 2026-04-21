
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float hSensitivity;
    public float vSensitivity;
    float xRotation = 0f;
    public Transform playerBody;

    // Start is called before the first frame update 
    void Start()
    {
    }

    // Update is called once per frame 
    void Update()
    {
        float h = hSensitivity * Input.GetAxis("Mouse X");
        float v = vSensitivity * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        playerBody.Rotate(Vector3.up * h);

        xRotation -= v;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



    }
}