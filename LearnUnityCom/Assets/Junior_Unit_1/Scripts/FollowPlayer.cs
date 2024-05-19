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
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offSet = new Vector3(0, 5, -7);
    void Awake()
    {
        
    }

    void Start()
    {
        
    }


    private void LateUpdate()
    {
        transform.position = player.transform.position + _offSet;
    }
}
