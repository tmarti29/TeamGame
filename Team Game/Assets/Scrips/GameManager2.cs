using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public GameObject Balls;
    private float spawnRate = 2.0f;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timerText;
    public Button restartButton;
    public GameObject titleScreen;
    private Coroutine spawnCoroutine;
    public static float player2Time;
    private int lives = 3;
    public float timer2 = 0.0f;

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        titleScreen.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        isGameActive = true;
        lives = 3;
        timer2 = 0.0f; 
        UpdateLives(0);
        UpdateTimer();
        StartCoroutine(TimerCountUp());
        spawnCoroutine = StartCoroutine(SpawnBalls());
    }
 
    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            float ranX = Random.Range(-10f, 10f);
            Vector3 spawnPos = new Vector3(ranX, 10, -0.5f);
            Instantiate(Balls, spawnPos, Quaternion.AngleAxis(0, Vector3.forward));
        }
    }

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timer2).ToString(); 
    }

    IEnumerator TimerCountUp()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1f);
            timer2 += 1f; 
            UpdateTimer();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        StopCoroutine(spawnCoroutine);
        player2Time = timer2;
        RestartGame();
    }

    public int GetTime2()
    {
        return Mathf.FloorToInt(player2Time);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("End");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
