using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 15;

    [SerializeField] private GameObject _projectilePrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            
        }
    }
}
