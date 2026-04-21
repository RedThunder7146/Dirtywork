using UnityEngine;
using UnityEngine.TerrainTools;
public class Scores : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            LevelManager.instance.AddPlayerScore(1);
        }
        if(Input.GetKey(KeyCode.KeypadMinus))
        {
            LevelManager.instance.AddPlayerScore(-1);
        }
    }
}
