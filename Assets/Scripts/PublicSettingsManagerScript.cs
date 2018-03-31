using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameSettingsLibrary;
using GameSettingsLibrary.Models;
using System;
using UnityEngine.Advertisements;
public class PublicSettingsManagerScript : MonoBehaviour {

    public GameSettingsModel settingsModel;
    public GameSettingsLibrary.GameManager gameManager;
#if UNITY_IOS
    private string gameId = "1752898";
#elif UNITY_ANDROID
    private string gameId = "1752899";
#endif

    private void Start()
    {
        try
        {
            Advertisement.Initialize(gameId, false);
        }
        catch(Exception ex)
        {
            throw ex;
        }
       
    }

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
            GameObject gameOver = GameObject.FindGameObjectWithTag("GameOver");
            if (gameOver != null)
            {
                platformSpeed = 0;
                spawnSpeed = 0;
                var gameOverSprite = gameOver.GetComponent<SpriteRenderer>();
                gameOverSprite.enabled = true;
            }
            GameObject ps = GameObject.FindGameObjectWithTag("Explosion");
            ParticleSystem particles = ps.GetComponent<ParticleSystem>();
            if (particles != null)
            {
                if (particles.isStopped)
                {
                    Advertisement.Show();
                    LoadBeginningLevel();
                }
            }
        }
    }

    public void LoadBeginningLevel()
    {
        platformSpeed = 2f;
        spawnSpeed = 2f;
        Exploded = false;
        SceneManager.LoadScene(0);
    }

}
