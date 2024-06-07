using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary> </summary>
public class Injector
{
    public enum ClientType
    {
        File, Display, Data
    }
    
    private ServiceStore _serviceStore;
    public Client client;
    public void Init(ClientType clientType)
    {
        IService service = null;
        switch (clientType)
        {
            case ClientType.Data: service = new Data(); break;
            case ClientType.Display: service = new Display(); break;
            case ClientType.File: service = new File(); break;
        }
        client.Inject(service);
    }

    void Start()
    {
        
    }

}
