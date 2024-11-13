using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
    
    private int lives = 3;
    private float timer = 0.0f;

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
        timer = 0.0f; 
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
        timerText.text = "Time: " + Mathf.FloorToInt(timer).ToString(); 
    }

    IEnumerator TimerCountUp()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1f);
            timer += 1f; 
            UpdateTimer();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        StopCoroutine(spawnCoroutine);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
