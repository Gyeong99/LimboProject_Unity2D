using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private bool moveBool = false;
    public CharacterController2D controller;

    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;
    public float accelerationRate = 1.0f;
    private float currentSpeed = 0.0f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        horizontalMove = -0.01f * runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBool)
        {
            if (currentSpeed < 1.0f)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
            }
        }
        horizontalMove = currentSpeed * runSpeed;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(horizontalMove) > 0.02f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveBool = true;
            Destroy(gameObject, 3.0f);
        }
        
    }
}
