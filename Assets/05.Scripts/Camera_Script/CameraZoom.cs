using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f; // �� �ӵ�
    public float minZoom = 5f; // �ּ� �� ũ��
    public float maxZoom = 10f; // �ִ� �� ũ��
    private bool zoomInBool = false;
    private bool zoomOutBool = false;
    void Update()
    {
        
        
        if (zoomInBool)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomSpeed, minZoom, maxZoom);
            
        }
        else if (zoomOutBool)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomSpeed, minZoom, maxZoom);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + zoomSpeed, minZoom, maxZoom);
        }
    }
}
