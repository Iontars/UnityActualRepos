using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 
/// </summary>
public class SpawnManager3 : MonoBehaviour
{

    [SerializeField] private GameObject _obstaclePrefab;
    private PlayerController3 _playerController3;
    
    private float _startDelay = 2;
    private float _repeatDelay = 2;
    private Vector3 _spawnPos = new(25, 0, 0);
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatDelay);
        _playerController3 = FindObjectOfType<PlayerController3>();
    }

    private void SpawnObstacle()
    {
        if (_playerController3.GameOver is false)
        {
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
