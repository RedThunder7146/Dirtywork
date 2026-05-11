using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    public GameObject body;
    public int bodyCount=0;

    private void Start()
    {
        int rndSpawn = Random.Range(0,10);
        if (rndSpawn <= 2 && LevelManager.instance.GetBodyCount() < 1000)
        {
            body = Instantiate(body, transform.position, transform.rotation);
            LevelManager.instance.AddBodyCount(1);
            print(bodyCount);
           
        }
       /* else
        {
            Destroy(gameObject);
        }*/

    }
}
