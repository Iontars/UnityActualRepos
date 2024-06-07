using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary> </summary>
public class ServiceStore{}

public interface IService
{
    string FormMessage();
}

public class Display : IService
{
    public string FormMessage()
    {
        return "Display message";
    }
}

public class Data : IService
{
    public string FormMessage()
    {
        return "Data message";
    }
}

public class File : IService
{
    public string FormMessage()
    {
        return "File message";
    }
    
}