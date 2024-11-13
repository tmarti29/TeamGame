using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 2.5f;
    int xrange = 10;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        MoveRight();
        BoundPlayer();
    }

    void MoveRight()
    {
        if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    void MoveLeft()
    {
        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void BoundPlayer()
    {
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }
    }

    // Detect when a ball hits the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balls"))
        {
            // Decrease life when a ball hits the player
            gameManager.UpdateLives(-1);
            Destroy(other.gameObject); // Destroy the ball
        }
    }
}
