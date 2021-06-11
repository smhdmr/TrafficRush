using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCars : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine("DestroyTimer");
    }

    void Update()
    {
        rb.velocity = new Vector3(0f, 0f, Global.otherCarsSpeed);
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(Global.otherCarsDestroyTime);
        Destroy(this.gameObject);
    }
}
