using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f; // ¡‹ º”µµ
    public float minZoom = 5f; // √÷º“ ¡‹ ≈©±‚
    public float maxZoom = 10f; // √÷¥Î ¡‹ ≈©±‚
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
