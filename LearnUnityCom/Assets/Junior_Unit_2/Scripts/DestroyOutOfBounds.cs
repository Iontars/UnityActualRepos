using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class DestroyOutOfBounds : MonoBehaviour
{

    private float _topBound = 40f;
    private float _lowerBound = -20f;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z > _topBound || transform.position.z < _lowerBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < _lowerBound)
        {
            print("Game Over");
        }
    }
}
