using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// 
/// </summary>
public class MaterialManager : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _materials;
    private AsyncOperationHandle _operationHandle;
    void Awake()
    {
        print(_materials[0]);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
