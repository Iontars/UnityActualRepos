using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 
/// </summary>
public class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject _player;
    private GameObject _currentGo;
    
    void Awake()
    {
        _currentGo = _player;
    }

    void Start()
    {
        Instantiate(_currentGo, transform.position, transform.rotation);
    }

    private void OnEnable()
    {
        
    }

    void Update()
    {
        
    }
}
