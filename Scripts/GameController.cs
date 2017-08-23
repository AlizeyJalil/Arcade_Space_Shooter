using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public float spawnWait;
    public float initialWait;
    public float waveWait;

    public GUIText scoreViewer;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText exitText;

    private bool gameO;
    private bool restart;
    private bool exit;

    private int score = 0;
    //public int pointsForDestroying;

    public int waveHazardCount;

    void Start()
    {
        StartCoroutine(spawnHazards());
        ScoreUpdate();

        restartText.text = "";
        gameOverText.text = "";
        exitText.text = "";

        gameO = false;
        restart = false;
        exit = false;

    }


    IEnumerator spawnHazards()
    {
        yield return new WaitForSeconds(initialWait);

        while (true)
        {

            for (int i = 1; i <= waveHazardCount; i++)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(-6.0f, 6.0f), 0.0f, 16.0f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameO)
            {
                restartText.text = "Press 'R' to restart the game!";
                exitText.text = "Pree 'E' to exit the game!";
                restart = true;
                exit = true;
                gameRestart();
                gameExit();
            }

           
        }
    }

    void Update()
    {
        if (restart)
        {
            gameRestart();
        }

        if (exit)
        {
            gameExit();
        }
    }



    public void AddScore()
    {
        score = score + 10;
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        scoreViewer.text = "Score: " + score;
    }

    void gameRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel (Application.loadedLevel);
        }
    }

    public void gameOver()
    {
        gameOverText.text = "Game Over!";
        gameO = true;
        gameRestart();
        gameExit();
    }

    void gameExit()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }
    }
	
}
