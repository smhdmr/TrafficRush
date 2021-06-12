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
        CarSpawner.Instance.RemoveFromActiveCars(this.gameObject);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelManager.Instance.GameOver();
        }

        else
        {
            CarSpawner.Instance.RemoveFromActiveCars(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
