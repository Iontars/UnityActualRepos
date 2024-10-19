using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using _2d_move.Scripts;
using Random = UnityEngine.Random;

public class MoveByStep : MonoBehaviour
{
    [SerializeField] private GameFieldsStorage _gameFieldsStorage;
    [SerializeField] private EventManager _eventManager;
    [SerializeField] [Range(0, 40)] private float _speed; 
    [SerializeField] [Range(0.1f, 2)] private float _delay;
    private bool isCanNewTurn = true;
    private int _targetPoint = 1;
    private int _nowPoint;
    private Vector2 _startMovePoint;
    
    void Awake()
    {
        // load from data
        if (_gameFieldsStorage._ActiveLocationListPoints != null && _gameFieldsStorage._ActiveLocationListPoints.Count > 0)
        {
            transform.position = _gameFieldsStorage.GetPoint(0).position;
        }
        _startMovePoint = transform.position;
        print(_gameFieldsStorage.GetPoint(0).position);
    }
    
    
    IEnumerator Moving(int diceValue)
    {
        for (; diceValue > 0; diceValue--)
        {
            if (_nowPoint == _gameFieldsStorage._ActiveLocationListPoints.Count - 1)
            {
                _targetPoint = 0;
            }
            if (_nowPoint == 10)
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
            if (_nowPoint == 4 && _eventManager.IsUnlockCrossroadGreenMap)
            {
                _targetPoint = Random.Range(0, 2) == 0 ? 11 : 5;
                print("!!!!!!"+ _targetPoint);
            }
            if (_nowPoint == 3 && _eventManager.IsUnlockWhiteMap)
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
