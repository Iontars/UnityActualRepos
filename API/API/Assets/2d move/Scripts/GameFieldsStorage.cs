using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class GameFieldsStorage : MonoBehaviour
{
    private List<Transform> _listPoints;

    [field: SerializeField] public List<GameObject> GreenZoneListPoints;
    [field: SerializeField] public List<GameObject> WhiteZoneListPoints;

    

    void Start()
    {
        
    }

    public Transform GetPoint(int value)
    {
        return value <= GreenZoneListPoints.Count ? GreenZoneListPoints[value].transform : throw new Exception("За пределами допустимых значений");
    }
    
    
}
