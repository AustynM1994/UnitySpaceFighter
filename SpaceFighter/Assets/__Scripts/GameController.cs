using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject enemy;

    private int score;
    private int highscore;
    private int enemiesRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 2;

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text highscoreText;

    // Use this for initialization
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BeginGame()
    {

        score = 0;
        lives = 3;
        wave = 1;

        scoreText.text = "SCORE:" + score;
        highscoreText.text = "HIGHSCORE: " + highscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnEnemies();
    }

    void SpawnEnemies()
    {

        DestroyExistingEnemies();

        //Decide how many Enemies to spawn
        enemiesRemaining = (wave * increaseEachWave);

        for (int i = 0; i < enemiesRemaining; i++)
        {

            //Spawn an Enemy
            Instantiate(enemy, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-12.0f, 12.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }

        waveText.text = "WAVE: " + wave;
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE:" + score;

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "HIGHSCORE: " + highscore;

            //Save the new hiscore
            PlayerPrefs.SetInt("Highscore", highscore);
        }

        //Check if player destroyed all enemies
        if (enemiesRemaining < 1)
        {

            //Start next wave
            wave++;
            SpawnEnemies();

        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        //Check if the player ran out of lives
        if (lives < 1)
        {
            //Restart the game if the player runs out of lives
            BeginGame();
        }
    }

    public void DecrementEnemies()
    {
        enemiesRemaining--;
    }

    void DestroyExistingEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyShip");

        foreach (GameObject current in enemies)
        {
            GameObject.Destroy(current);
        }
    }
}