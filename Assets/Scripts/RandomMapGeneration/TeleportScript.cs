using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportPos;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "houseTrig")
        {
            transform.position = teleportPos.transform.position;

            print("Trigger");
        }
    }
}
