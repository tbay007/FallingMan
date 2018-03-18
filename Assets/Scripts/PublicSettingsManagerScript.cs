using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PublicSettingsManagerScript : MonoBehaviour {

    public static float platformSpeed = 2f;

    public static float spawnSpeed = 2f;

    public static int Level = 1;
    public static string LevelString = "Level: " + Level.ToString();

    public static int score = 0;
    public static string ScoreString = "Score: 0";

    public static bool Exploded = false;
    public static void CheckLevel()
    {
        if (score % 5 == 0 && Level != 100)
        {
            platformSpeed += 0.05f;
            spawnSpeed = spawnSpeed - (spawnSpeed * 0.05f);
            Level += 1;
            LevelString = "Level: " + Level.ToString();
        }
    }

    private void Update()
    {
        if (Exploded)
        {
            GameObject ps = GameObject.FindGameObjectWithTag("Explosion");
            ParticleSystem particles = ps.GetComponent<ParticleSystem>();
            if (particles.isStopped)
            {
                LoadBeginningLevel();
            }
        }
    }

    public void LoadBeginningLevel()
    {
        SceneManager.LoadScene(0);
    }

}
