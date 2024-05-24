using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>  </summary>
public class ReflectClass : MonoBehaviour
{

    [SerializeField] private SameData _sameData;
    private List<int> value = new ();
    

    void Start()
    {
        ViewFields(_sameData);
    }

    private void ViewFields(SameData sameData)
    {
        var field = sameData.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        
        foreach (var item in field)
        {
            value.Add((int)item.GetValue(sameData));
        }

        foreach (var item in value)
        {
            print(item);
        }
    }
    
}