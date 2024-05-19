using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 
/// </summary>
public class MoveForward : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        
    }
}
