using UnityEngine;

public class HallucinationScript : MonoBehaviour
{

    public GameObject spawner;
    public bool willSpawn;
    public SanityBar sanityBar;
    public Transform hallucination;
    public GameObject halluGameObj;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(80, 100);


        float sanity = sanityBar.sanity;

        if (rnd <= sanity)
        {
            willSpawn = true;
        }

        else
        {
            willSpawn = false;
        }


        Vector3 spawnerPosition = hallucination.position;

        
        if (willSpawn == true)
        {
            spawner.SetActive(true);
            halluGameObj.SetActive(false);
            
        }
    }
}
