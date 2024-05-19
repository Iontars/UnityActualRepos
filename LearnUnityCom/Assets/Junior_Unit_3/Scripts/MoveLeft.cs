using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;
    private PlayerController3 _playerController3;
    private float _leftBounds;

    private void Start()
    {
        _playerController3 = FindObjectOfType<PlayerController3>();
        if (Camera.main != null) _leftBounds = ObjectEdges.GetLeftCameraEdge(Camera.main) + 1;
    }

    void Update()
    {
        
        if (_playerController3.GameOver is false)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
        
        if (transform.position.x < _leftBounds && gameObject.CompareTag($"Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
