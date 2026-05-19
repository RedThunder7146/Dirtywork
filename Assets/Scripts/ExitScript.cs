using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameObject[] meshes;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            if (gameObject.tag == "Part")
            {
                print("Destroy" + gameObject);
                Destroy(gameObject);
            }


            if (gameObject.tag == "Pickup")
            {
                foreach (GameObject mesh in meshes)
                {
                    print("Destroy " + mesh);
                    Destroy(mesh);
                }


                print("Destroy " + gameObject);
                LevelManager.instance.SubBodyCount(1);
                print(LevelManager.instance.GetSubbedBodyCount());
                Destroy(gameObject);
                LevelManager.instance.ResetScene();
            }
        }


        
    }
}
