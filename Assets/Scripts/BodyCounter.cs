using TMPro;
using UnityEngine;

public class BodyCounter : MonoBehaviour
{
    public TextMeshPro bodyCounter;







    // Update is called once per frame
    void Update()
    {
        bodyCounter.text = LevelManager.instance.BodyCounter().ToString("00");
    }
}
