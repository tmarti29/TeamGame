using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Balls;
    private float spawnRate = 2.0f;
    public bool isGameActive;
    public float ranX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnBalls());
    }
    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            ranX = Random.Range(-10f, 10f);
            Vector3 spawnPos = new Vector3(ranX, 10, 0);
            Instantiate(Balls[0], spawnPos, Quaternion.AngleAxis(0,Vector3.forward));
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Closes the game when esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
