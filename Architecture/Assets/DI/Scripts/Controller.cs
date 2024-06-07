using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary> </summary>
public class Controller : MonoBehaviour
{
    [SerializeField] private Injector _injector;
    [SerializeField] private Client _client;
    void Awake()
    {
        _injector = new Injector();
        _injector.client = _client;
        _injector.Init(Injector.ClientType.Data);
    }
}
