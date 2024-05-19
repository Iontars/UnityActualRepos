using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public static int CubNumberResult { get; private set; }
    public static event Action OnCubeRolled;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void RollValue()
    {
        CubNumberResult = Random.Range(1, 7);
        OnCubeRolled?.Invoke();
        print("Выпало " + CubNumberResult);
    }
    public void RollValue1()
    {
        CubNumberResult = 1;
        OnCubeRolled?.Invoke();
        print("Выпало " + CubNumberResult);
    }
}
