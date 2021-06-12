using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public float minPitch;
    public float maxPitch;
    private float currentPitch;
    private AudioSource audioSource;

    #region Instance
    public static EngineSound Instance;
     void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        currentPitch = Car.Instance.rb.velocity.z - Car.Instance.idleForwardSpeed;
        float temp = Car.Instance.maxSpeed - Car.Instance.idleForwardSpeed;
        currentPitch /= temp;
        temp = maxPitch - minPitch;
        currentPitch *= temp;
        currentPitch += minPitch;

        audioSource.pitch = currentPitch;

    }


    public void SetEngineSound(bool isPlaying)
    {

        switch (isPlaying)
        {
            case true:
                audioSource.Play();
                break;

            case false:
                audioSource.Stop();
                break;
        }
    }


}
