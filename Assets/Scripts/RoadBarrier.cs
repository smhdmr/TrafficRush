using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBarrier : MonoBehaviour
{    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelManager.Instance.GameOver();
        }
    }

}
