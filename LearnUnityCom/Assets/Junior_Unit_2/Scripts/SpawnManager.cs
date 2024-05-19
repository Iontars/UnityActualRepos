using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _animalPrefabs;
    [SerializeField] private int _animalIndex;
    private float _spawnRangeX = 13;
    private float _spawnRangeZ = 30;
    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;
    private Vector3 _spawnPos;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnInterval);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    private void SpawnRandomAnimal()
    {
        _spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX + 1), 0, _spawnRangeZ);
        _animalIndex = Random.Range(0, _animalPrefabs.Length);
        GameObject currentGo = Instantiate(_animalPrefabs[_animalIndex], _spawnPos,
            _animalPrefabs[_animalIndex].transform.rotation);
    }
}
