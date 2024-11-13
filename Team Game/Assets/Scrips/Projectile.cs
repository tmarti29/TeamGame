using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;
    private Vector3 startPosition;
    public float maxDistance = 10.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = transform.up * speed * Time.deltaTime;
        transform.position += movement;

        if (Vector3.Distance(startPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balls"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
