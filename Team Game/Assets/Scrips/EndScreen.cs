using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI P1Time;
    public TextMeshProUGUI P2Time;
    public static float Play1Time;
    public static float Play2Time;
    // Start is called before the first frame update
    void Start()
    {
        Play1Time = GameManager.player1Time;
        Play2Time = GameManager2.player2Time;
        P1Time.text = "Player 1 Time: " + Play1Time;
        P2Time.text = "Player 2 Time: " + Play2Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Transition");
        }
    }
}
