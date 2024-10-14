using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveByStep : MonoBehaviour
{
    [SerializeField] private GameFieldsStorage _gameFieldsStorage;
    [SerializeField] [Range(0, 40)] private float _speed; 
    [SerializeField] [Range(0.1f, 2)] private float _delay;
    private bool isCanNewTurn = true;
    private int _targetPoint = 1;
    private int _nowPoint;
    private Vector2 _startMovePoint;
    
    void Awake()
    {
        
        if (_gameFieldsStorage._ActiveLocationListPoints != null && _gameFieldsStorage._ActiveLocationListPoints.Count > 0)
        {
            transform.position = _gameFieldsStorage.GetPoint(0).position;
        }
        _startMovePoint = transform.position;
        print(_gameFieldsStorage.GetPoint(0).position);
    }
    
    
    IEnumerator Moving(int value)
    {
        for (; value > 0; value--)
        {
            if (_targetPoint == _gameFieldsStorage._ActiveLocationListPoints.Count)
            {
                _targetPoint = 0;
            }
            yield return new WaitForSeconds(_delay);
            while (Vector2.Distance(_startMovePoint, _gameFieldsStorage.GetPoint(_targetPoint).position) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _gameFieldsStorage.GetPoint(_targetPoint).position, _speed * Time.deltaTime); 
                _startMovePoint = transform.position;
                yield return null;
            }
            _targetPoint++;
            _nowPoint = _targetPoint - 1;
        }
    }
    

    private IEnumerator OnReachedPoint()
    {
        yield return StartCoroutine(Moving(Dice.CubNumberResult));
        if (_gameFieldsStorage.GetActivateLocation() == GameFieldsStorage.ActiveLocation.Green)
        {
            if (_nowPoint == 4)
            {
                _targetPoint = 11;
            }
            if (_nowPoint == 3)
            {
                _gameFieldsStorage.SetActiveLocation(GameFieldsStorage.ActiveLocation.White);
                _targetPoint = 0;
            }
            if (_nowPoint == 10)
            {
                _targetPoint = 0;
            }
        }
        else if (_gameFieldsStorage.GetActivateLocation() == GameFieldsStorage.ActiveLocation.White)
        {
            if (_nowPoint == 5)
            {
                _targetPoint = 10;
            }
            if (_nowPoint == 8)
            {
                _gameFieldsStorage.SetActiveLocation(GameFieldsStorage.ActiveLocation.Green);
                _targetPoint = 5;
            }
        }
        print(_nowPoint);
        isCanNewTurn = true;
    }
    
    void Update()
    {
        
    }

    private void StartHeroMove()
    {
        if (isCanNewTurn)
        {
            isCanNewTurn = false;
            StartCoroutine(nameof(OnReachedPoint));
        }
    }

    private void OnDisable()
    {
        Dice.OnCubeRolled -= StartHeroMove;
    }

    private void OnEnable()
    {
        Dice.OnCubeRolled += StartHeroMove;
    }
}
