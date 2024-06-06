using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> </summary>

public interface IShootable
{
    public string Shoot();
}

public interface IAmmo
{
    public string Name { get; set; }
}


public abstract class Weapon : IShootable
{
    protected Weapon(IAmmo ammo)
    {
        Ammo = ammo;
    }
    private IAmmo Ammo { get;}
    public string Shoot()
    {
        return $"стреляю {Ammo.Name} патроном";
    }
}

public class Pistol : Weapon
{
    public Pistol(IAmmo ammo) : base(ammo)
    {
    }
}
public abstract class Ammo : IAmmo
{
    protected Ammo()
    {
        Name = "";
    }

    public string Name { get; set; }
    
}

public class FMJAmmo : Ammo
{
    public FMJAmmo()
    {
        Name = "FMJ";
    }
}

