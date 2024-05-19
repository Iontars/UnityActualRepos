#region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;
#endregion

/// <summary> Descriptions </summary>
public class SpinPropellerX : MonoBehaviour
{
    void Awake()
    {
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0,0, 40);
    }
}
