using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float idleForwardSpeed;
    public float maxSpeedIncrease;
    private float forwardSpeed;
    public float xSpeed;
    public float speedDecreaseFactor;

    private float speedIncreaseTime;
    public float maxSpeedIncreaseTime;

    private Rigidbody rb;    


    void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }
       

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            speedIncreaseTime += Time.deltaTime;

            if(speedIncreaseTime > maxSpeedIncreaseTime)            
                speedIncreaseTime = maxSpeedIncreaseTime;

            forwardSpeed = idleForwardSpeed + (maxSpeedIncrease / maxSpeedIncreaseTime * speedIncreaseTime);
                        
            rb.velocity = new Vector3(0f, 0f, forwardSpeed);
            Debug.Log(forwardSpeed);
        }

        else
        {
            speedIncreaseTime -= Time.deltaTime;

            if (speedIncreaseTime < 0f)
                speedIncreaseTime = 0f;

            forwardSpeed = idleForwardSpeed + (maxSpeedIncrease * speedIncreaseTime / maxSpeedIncreaseTime / speedDecreaseFactor);

            rb.velocity = new Vector3(0f, 0f, forwardSpeed);
            Debug.Log(forwardSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-xSpeed, rb.velocity.y, rb.velocity.z);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(xSpeed, rb.velocity.y, rb.velocity.z);
        }

        

    }
}
