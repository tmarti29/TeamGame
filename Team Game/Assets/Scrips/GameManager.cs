using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Balls;
    private float spawnRate = 2.0f;
    public bool isGameActive;

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
            Instantiate(Balls);
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
