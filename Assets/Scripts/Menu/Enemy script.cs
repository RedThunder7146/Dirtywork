using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TerrainTools;
public class Enemyscript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minDist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.GetPlayerHealth() < 3)
        {
            speed = 5f;
        }
        else
        {
            speed = 4f;
        }

        if (target == null)
            return;

        
        transform.LookAt(target);

        
        float distance = Vector3.Distance(transform.position, target.position);

        
        if (distance < minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelManager.instance.AddPlayerHealth(1);
            print(LevelManager.instance.GetPlayerHealth());
        }
    }
}
