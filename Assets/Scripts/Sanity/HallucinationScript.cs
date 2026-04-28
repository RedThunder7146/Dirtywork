using UnityEngine;

public class HallucinationScript : MonoBehaviour
{

    public GameObject spawner;
    public bool willSpawn;
    public SanityBar sanityBar;
    public Transform hallucination;
    public GameObject halluGameObj;
    public int rnd;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rnd = Random.Range(70, 90);

        if (sanityBar == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                sanityBar = GameObject.FindWithTag("Player").GetComponent<SanityBar>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sanityBar.halluMult = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sanityBar.halluMult = 1;
        }
    }
}
