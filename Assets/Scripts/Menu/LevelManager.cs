using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;
public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    private int playerHealth;
    private int playerScore;
    private int highScore;
    private int timesPlayed;
    public static float brightness;

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
    public void Start()
    {
        // Before reading the key, check to see if a value has been stored in it.
        if (PlayerPrefs.HasKey("highScore") == true)
        {
            // the key musicVol holds a value, therefore we can
            //retrieve it and store it in a variable
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            // the key musicVol is null so give it a default value of 0.5f
            PlayerPrefs.SetInt("highScore", 0);
        }

        if (PlayerPrefs.HasKey("timesPlayed") == true)
        {
            // the key musicVol holds a value, therefore we can
            //retrieve it and store it in a variable
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
            timesPlayed += 1;
            PlayerPrefs.SetInt("timesPlayed", timesPlayed);

        }
        else
        {
            // the key musicVol is null so give it a default value of 0.5f
            PlayerPrefs.SetInt("timesPlayed", 0);

            Scene scene = SceneManager.GetActiveScene();
        }
    }

    public void SetPlayerHealth(int pHealth)
    {
        playerHealth = pHealth;
    }
    public void AddPlayerHealth(int pHealthDep)
    {
        playerHealth -= pHealthDep;
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }
    public void AddPlayerScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        SetHighScore();
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void SetHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }
    public int GetTimesPlayed()
    {
        return timesPlayed;
    }




}
