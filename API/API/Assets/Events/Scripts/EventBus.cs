using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Console;
using Random = UnityEngine.Random;

public enum GameState
{
    Play, Pause, Load
}

// comment
public class EventBus : MonoBehaviour
{
    public delegate void DataProcessorEventHandler(GameObject data);
    public event DataProcessorEventHandler OnDataCall;
    public Action<GameObject> Action;
    //private string _heroName = "Batman";
    public const float Speed = 134.4567f;
    public readonly float SpeedSet = 134.45f;
    //private GameState _gameState = new();
    private GameObject _go;

    private void Awake()
    {
        _go = Resources.Load<GameObject>("Circle");
    }

    void Start()
    {
        OnDataCall += DoData;
        //OnDataCall?.Invoke(_gameState as object);
        Action += DoData;
        
        StartCoroutine(DoWhenItDone(() =>
        {
            string firstWord = "Загрузка";
            string secondWord = "завершена";
            print($"{firstWord} {secondWord}");
        }));
        
        StartCoroutine(DoWhenItDone(() => print("Загрузка завершена")));
        StartCoroutine(DoWhenItDone(() => DoData(_go)));
    }
    
    public void DoData(GameObject obj)
    {
        print($"hello + {obj.name}");
    }

    public IEnumerator DoWhenItDone(Action callback)
    {
        print("Загрузка...");
        if (Random.Range(0, 2) < 1)
        {
            yield return new WaitForSeconds(1f);
            callback();
        }
        else
        {
            print("Ошибка загрузки");
        }
    }
}
