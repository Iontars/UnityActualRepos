using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{

    private Vector3 _startPos;
    private float _repeatWight;
    void Start()
    {
        _startPos = transform.position;
        _repeatWight = GetComponent<BoxCollider>().size.x / 2;
        print(_repeatWight);
    }

    void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWight)
        {
            transform.position = _startPos;
        }
    }
}
