using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCtrl : MonoBehaviour
{
    public float rotationSpeed = 100f; // ȸ�� �ӵ�

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
