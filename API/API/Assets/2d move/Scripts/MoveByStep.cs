using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveByStep : MonoBehaviour
{
    [SerializeField] private GameFieldsStorage _pointStorage;
    [SerializeField] [Range(0, 40)] private float _speed; 
    [SerializeField] [Range(0.1f, 2)] private float _delay;
    private bool isCanNewTurn = true;
    private int _targetPoint = 1;
    private int _nowPoint;
    private Vector2 _startMovePoint;
    
    void Awake()
    {
        if (_pointStorage != null && _pointStorage.GreenZoneListPoints.Count > 0)
        {
            transform.position = _pointStorage.GetPoint(0).position;
        }
        _startMovePoint = transform.position;
    }

    void Start()
    {
        
    }
    
    IEnumerator Moving(int value)
    {
        for (; value > 0; value--)
        {
            if (_targetPoint == _pointStorage.GreenZoneListPoints.Count)
            {
                _targetPoint = 0;
            }
            yield return new WaitForSeconds(_delay);
            while (Vector2.Distance(_startMovePoint, _pointStorage.GetPoint(_targetPoint).position) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _pointStorage.GetPoint(_targetPoint).position, _speed * Time.deltaTime); 
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
        
        
        if (_targetPoint == 5)
        {
            _targetPoint = 11;
        }
        print("приехали");
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
