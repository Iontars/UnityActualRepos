using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private readonly Vector3 _offset = new Vector3(0, 3, -15);
    
    public float cameraDistance = 10f;
    public float cameraHeight = 5f;
    public float cameraRotationDamping = 3f;
    public float cameraHeightDamping = 2f;

    //cameraDistance - расстояние между камерой и объектом 
    //cameraHeight - высота камеры над объектом
    //cameraRotationDamping - коэффициент затухания поворота камеры
    //cameraHeightDamping - коэффициент затухания высоты камеры
    
    //Метод Vector3.Lerp() используется для постепенного изменения позиции камеры с учетом
    //заданных параметров. Метод Quaternion.LookRotation() используется для вычисления ориентации
    //камеры на объект. Метод Quaternion.Slerp() используется для постепенного изменения ориентации
    //камеры с учетом заданного коэффициента затухания.
    //Этот код поможет вам настроить камеру так, чтобы она следила за объектом и поворачивалась вместе с ним, как в компьютерных играх.
    
    void Start()
    {
        transform.position = plane.transform.position;
    }
    
    void Update()
    {
        // Позиционируем камеру с учетом заданного расстояния и высоты
        Vector3 targetPosition = plane.transform.position - plane.transform.forward * cameraDistance;
        targetPosition.y += cameraHeight;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraHeightDamping);

        // Ориентируем камеру на объект
        Quaternion targetRotation = Quaternion.LookRotation(plane.transform.position - transform.position, plane.transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * cameraRotationDamping);
        
    }
}
