using UnityEngine;

public class SoundMaker : MonoBehaviour
{
    public int soundRND;
    public int rndSound;
    public float timer;
    public string sound;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundRND = Random.Range(0, 30);
        rndSound = Random.Range(0, 4);
        timer += Time.deltaTime;

        if (rndSound == 0)
        {
            sound = "TerrifyingWind";
        }

        if (rndSound == 1)
        {
            sound = "EerieWind";
        }

        if (rndSound == 2)
        {
            sound = "EerieWind2";
        }

        if(rndSound == 3)
        {
            sound = "Knocking";
        }

        if (rndSound == 4)
        {
            sound = "SneakOnWood";
        }


        if (timer <= soundRND )
        {
            AudioManager.instance.PlaySoundEffect(sound);
            soundRND = Random.Range(0, 30);
            rndSound = Random.Range(0, 4);
            timer = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
