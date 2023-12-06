using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCtrl : MonoBehaviour
{
    public float rotationSpeed = 100f; // 회전 속도

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
