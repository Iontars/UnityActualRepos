using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class GameFieldsStorage : MonoBehaviour
{
    public enum ActiveLocation
    {
        Green, White
    }
    
    [field: SerializeField] public List<GameObject> _ActiveLocationListPoints;
    [field: SerializeField] private List<GameObject> GreenZoneListPoints;
    [field: SerializeField] private List<GameObject> WhiteZoneListPoints;
    [SerializeField] private ActiveLocation activeLocation;
    

    void Awake()
    {
        SetActiveLocation(activeLocation); // from data
    }
    
    public void SetActiveLocation(ActiveLocation setActiveLocation)
    {
        activeLocation = setActiveLocation;
        switch (activeLocation)
        {
            case ActiveLocation.Green : 
                _ActiveLocationListPoints.Clear();
                _ActiveLocationListPoints.AddRange(GreenZoneListPoints);
                break;
            case ActiveLocation.White : 
                _ActiveLocationListPoints.Clear();
                _ActiveLocationListPoints.AddRange(WhiteZoneListPoints);
                break;
        }
    }

    public ActiveLocation GetActivateLocation() => activeLocation;

    public Transform GetPoint(int value)
    {
        return value <= _ActiveLocationListPoints.Count ? _ActiveLocationListPoints[value].transform : throw new Exception("За пределами допустимых значений");
    }
    
    
}
