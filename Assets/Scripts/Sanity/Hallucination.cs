using UnityEngine;

public class Hallucination : MonoBehaviour
{
    public GameObject[] hallucinations;
    public bool willSpawn;
    public SanityBar sanityBar;
    public Transform spawner;

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, 60);


        float sanity = sanityBar.sanity;

        if (rnd >= sanity)
        {
            willSpawn = true;
        }

        else
        {
            willSpawn=false;
        }


        Vector3 hallucinationPosition = spawner.position;

        int hallucination = Random.Range(0, hallucinations.Length);
        GameObject rndHallucination = hallucinations[hallucination];
        if (willSpawn == true)
        {
            Instantiate(rndHallucination, transform.position,transform.rotation);
        }
        rndHallucination.AddComponent<HallucinationScript>();



        Destroy(gameObject);

    }
}
