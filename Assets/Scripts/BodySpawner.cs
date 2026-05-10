using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    public GameObject body;
    public int bodyCount=0;

    private void Start()
    {
        int rndSpawn = Random.Range(0,10);
        if (rndSpawn <= 10 && bodyCount < 4)
        {
            body = Instantiate(body, transform.position, transform.rotation);
            bodyCount += 1;
            print(bodyCount);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
