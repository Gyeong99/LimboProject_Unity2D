using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float accelerationRate = 1.0f;
    private float currentSpeed = 0.0f;
    private bool moveBool = false;
    private bool stopBool = false;
    public Transform boatTr;
    public Transform playerTr;

    private void Start()
    {
        
    }
    void Update()
    {

        
        if (boatTr.transform.position.x >= 76.26)
        {
            stopBool = true;
        }
        if (moveBool && !stopBool)
        {
            if (currentSpeed < 3.0f)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
            }
            boatTr.Translate(currentSpeed * Vector3.right * Time.deltaTime);
            playerTr.Translate(currentSpeed * Vector3.right * Time.deltaTime);
        }
        // 오른쪽으로 가속 운동
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveBool = true;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            stopBool = true;
        }

    }
}
