using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

/// <summary> </summary>
public class Client : MonoBehaviour
{
    [SerializeField] private Button _actionButton;
    private IService _service;
    
    public void Inject(IService service)
    {
        _service = service;
    }

    public void SendMessage()
    {
        print(_service != null ? _service.FormMessage() : FormError());
    }

    private string FormError() => "Сервис не загружен";
    private void OnEnable() => _actionButton.onClick.AddListener(SendMessage);
    private void OnDisable() => _actionButton.onClick.RemoveListener(SendMessage);

}
