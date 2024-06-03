using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WaitForSeconds = UnityEngine.WaitForSeconds;

public class TimeDalayS : MonoBehaviour
{
    private int delaySec = 2;
    int current = 0;
    void Start()
    {
        StartCoroutine(CorRepeat(() => DisplayPrint(current), delaySec));
    }

    public void DisplayPrint(int value)
    {
        print(value);
    }

    public void UpdateRepeat(Action callback, int delay)
    {
        if (current < Time.time)
        {
            callback?.Invoke();
            current = (int) (delay + Time.time);
        }
    }

    public IEnumerator CorRepeat(Action callback, int delay)
    {
        while (true)
        {
            callback?.Invoke();
            yield return new WaitForSeconds(delay);
        }
    }
    
    private void Update()
    {
        //UpdateRepeat(() => DisplayPrint(current), delaySec);
    }
}
