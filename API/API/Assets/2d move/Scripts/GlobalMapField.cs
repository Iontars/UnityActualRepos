using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(SpriteRenderer))]
public class GlobalMapField : MonoBehaviour
{
    public int Number { get; set; }
    public string Name { get; set; }
    public Sprite Picture { get; set; }

    private SpriteRenderer _spriteRenderer;
    
    public GlobalMapField(int number, string name)
    {
        Number = number;
        Name = name;
        //Picture = picture;
    }

    void Awake()
    {
       // _spriteRenderer.sprite = Picture;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
