using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Transform armTransform; 
    public float rotateSpeed = 100f; 

    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        armTransform.RotateAround(transform.position, Vector3.forward, horizontalInput * rotateSpeed * Time.deltaTime);
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.transform.rotation = armTransform.rotation; 
        }
    }
}
