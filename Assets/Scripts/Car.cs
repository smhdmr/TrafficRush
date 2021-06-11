using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float idleSpeed;

    private Rigidbody rb;
    private GameObject leftWheel, rightWheel;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        leftWheel = transform.GetChild(3).gameObject;
        rightWheel = transform.GetChild(0).gameObject;
    }
       

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0f, 0f, idleSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(new Vector3(-1f, 0f, 0f), rightWheel.transform.position, ForceMode.Force);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(new Vector3(1f, 0f, 0f), rightWheel.transform.position, ForceMode.Force);
        }

    }
}
