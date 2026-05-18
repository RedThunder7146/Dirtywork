using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public Transform pelvis;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Part")
        {
            other.transform.parent = pelvis;
        }


        if (other.gameObject.tag == "Pickup")
        {
            LevelManager.instance.SubBodyCount(1);
            print(LevelManager.instance.GetSubbedBodyCount());
            Destroy(other.gameObject);
            LevelManager.instance.ResetScene();
        }
    }
}
