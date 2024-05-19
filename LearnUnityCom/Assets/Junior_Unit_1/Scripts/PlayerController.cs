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
public class PlayerController : MonoBehaviour
{
    private readonly float _speed = 20f;
    private float _turnSpeed = 30;
    private float _horizontalInput;
    private float _forwardInput;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }


    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * (_forwardInput * _speed * Time.deltaTime));
        transform.Rotate(Vector3.up, _turnSpeed * _horizontalInput * Time.deltaTime);
    }
}
