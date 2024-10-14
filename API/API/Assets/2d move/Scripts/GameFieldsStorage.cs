using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class GameFieldsStorage : MonoBehaviour
{
    enum ActiveLocation
    {
        Green, White
    }
    
    [field: SerializeField] public List<GameObject> _ActiveLocationListPoints;

    [field: SerializeField] public List<GameObject> GreenZoneListPoints;
    [field: SerializeField] public List<GameObject> WhiteZoneListPoints;

    

    void Start()
    {
        _ActiveLocationListPoints.Clear();
        _ActiveLocationListPoints.AddRange(GreenZoneListPoints);
        // ActiveLocation activeLocation = ActiveLocation.Green;
        // switch (activeLocation)
        // {
        //     case ActiveLocation.Green : _ActiveLocationListPoints = GreenZoneListPoints; break;
        //     case ActiveLocation.White : _ActiveLocationListPoints = WhiteZoneListPoints; break;
        // }
    }

    public Transform GetPoint(int value)
    {
        return value <= GreenZoneListPoints.Count ? GreenZoneListPoints[value].transform : throw new Exception("За пределами допустимых значений");
    }
    
    
}
