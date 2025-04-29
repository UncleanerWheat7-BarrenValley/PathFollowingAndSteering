using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 15;
    public float acceleration = 5;
    public float maxTurnSpeed = 100;
    public float brakeForce = 15;

    Rigidbody rb;
    float currentSpeed = 0;
    float currentTurnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        moveKart();
    }


    private void HandleInput()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= brakeForce * Time.deltaTime;
        }
        else
        {
            currentSpeed -= brakeForce * Time.deltaTime * 0.5f;
        }

        currentSpeed = Math.Clamp(currentSpeed, 0, maxSpeed);

        if (currentSpeed < maxSpeed * 0.66)
        {
            currentTurnSpeed = currentSpeed * currentSpeed;
        }
        else
        {
            currentTurnSpeed = maxTurnSpeed;
        }


        transform.Rotate(0, turnInput * currentTurnSpeed * Time.deltaTime, 0);
    }
    private void moveKart()
    {
        Vector3 movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
