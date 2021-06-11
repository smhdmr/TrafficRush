using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    private int placementOffset = 3835;
    private GameObject roadsParent;
    private GameObject thisRoad;
    private GameObject otherRoad;

    void Awake()
    {
        roadsParent = GameObject.FindGameObjectWithTag("RoadsParent");
        thisRoad = this.transform.parent.gameObject;

        if (thisRoad == roadsParent.transform.GetChild(0).gameObject)
            otherRoad = roadsParent.transform.GetChild(1).gameObject;

        else if (thisRoad == roadsParent.transform.GetChild(1).gameObject)
            otherRoad = roadsParent.transform.GetChild(0).gameObject;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            otherRoad.transform.position = new Vector3(otherRoad.transform.position.x, otherRoad.transform.position.y, thisRoad.transform.position.z + placementOffset);            
        }
    }

}
