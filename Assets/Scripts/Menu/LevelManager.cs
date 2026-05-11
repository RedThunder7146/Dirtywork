using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;
public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    private int totalBodies;
    private int bodies;


    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }
public void AddBodyCount(int bodyCount)
    {
        totalBodies += bodyCount;
        print(totalBodies);

        bodies = totalBodies;
    }

    public int GetBodyCount()
        { return totalBodies; }

    public void SubBodyCount(int bodyCount)
    {
        bodies -= bodyCount;
    }

    public int GetSubbedBodyCount()
    {
        return bodies;
    }

    public void ResetScene()
    {
        if (10<= GetBodyCount() - GetSubbedBodyCount())
        {
            SceneManager.LoadScene(1);
        }
    }


}
