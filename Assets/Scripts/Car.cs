using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("Speeds and Forces")]
    public float idleForwardSpeed;
    public float maxSpeed;    
    public float xSpeed;
    public float throttlePower;
    public float brakePower;
    public float windBrakePower;

    [Header("Car Detection")]
    public float carDetectionDistance;
    public float carDetectionCooldown;
    public LayerMask rayMask;

    //CAR DETECT STATUS
    private bool isCarDetectedL = false;
    private bool isCarDetectedR = false;
    private bool isDetectionActiveL = true;
    private bool isDetectionActiveR = true;    

    //COMPONENTS
    [HideInInspector]
    public Rigidbody rb;
    private Transform rayPointL, rayPointR;

    //INSTANCE
    public static Car Instance;


    void Awake()
    {
        Instance = this;

        //GET NECESSARY GAMEOBJECTS and COMPONENTS
        rb = GetComponent<Rigidbody>();
        rayPointL = transform.GetChild(5);
        rayPointR = transform.GetChild(6);        
    }       

    
    void Update()
    {

        #region MOVEMENT
        //THROTTLE
        if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.z >= idleForwardSpeed && rb.velocity.z < maxSpeed)
                rb.AddForce(0f, 0f, throttlePower, ForceMode.Acceleration);            

            else if (rb.velocity.z < idleForwardSpeed)
                rb.velocity = new Vector3(0f, 0f, idleForwardSpeed);
        }

        //BRAKE
        else if (Input.GetKey(KeyCode.D))
        {  

            if(rb.velocity.z > idleForwardSpeed)
                rb.AddForce(0f, 0f, -brakePower, ForceMode.Acceleration);

            else if (rb.velocity.z < idleForwardSpeed)
                rb.velocity = new Vector3(0f, 0f, idleForwardSpeed);
        }

        //WIND BRAKE
        else
        {
            if (rb.velocity.z > idleForwardSpeed)
                rb.AddForce(0f, 0f, -windBrakePower, ForceMode.Acceleration);

            else if  (rb.velocity.z < idleForwardSpeed)
                rb.velocity = new Vector3(0f, 0f, idleForwardSpeed);
        }

        //LEFT MOVEMENT
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-xSpeed, rb.velocity.y, rb.velocity.z);
        }

        //RIGHT MOVEMENT
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(xSpeed, rb.velocity.y, rb.velocity.z);
        }

        //NO MOVEMENT IN X
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
        }
        #endregion

        #region CAR DETECTION
        if (Physics.Raycast(rayPointL.position, Vector3.left, 5f, rayMask, QueryTriggerInteraction.Ignore) && isDetectionActiveL)
        {
            isCarDetectedL = true;
        }

        if (Physics.Raycast(rayPointR.position, Vector3.right, 5f, rayMask, QueryTriggerInteraction.Ignore) && isDetectionActiveR && !isCarDetectedR)
        {
            isCarDetectedR = true;
        }

        //CHECK FOR SCORE AWARD
        ScoreController.Instance.CheckAward(isCarDetectedL, isCarDetectedR);

        //CHECK FOR COOLDOWN
        if (isCarDetectedL)
        {
            StartCoroutine("CarDetectionCooldownL");
        }

        if (isCarDetectedR)
        {
            StartCoroutine("CarDetectionCooldownR");
        }
        #endregion

    }

    #region CAR DETECION COOLDOWNS
    private IEnumerator CarDetectionCooldownL()
    {
        isCarDetectedL = false;
        isDetectionActiveL = false;        
        yield return new WaitForSeconds(carDetectionCooldown);
        isDetectionActiveL = true;
    }

    private IEnumerator CarDetectionCooldownR()
    {
        isCarDetectedR = false;
        isDetectionActiveR = false;
        yield return new WaitForSeconds(carDetectionCooldown);
        isDetectionActiveR = true;
    }
    #endregion
}
