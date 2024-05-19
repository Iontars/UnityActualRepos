using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class GameFieldPoint : MonoBehaviour
{
    [SerializeField] private Text textComp;
    
    [field: SerializeField][Range(0, 100)] public int Id;

    private void Awake()
    {
        if (textComp != null)
        {
            textComp.text = Id.ToString();
        }
    }
    
}
