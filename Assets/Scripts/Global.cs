using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    //GLOBAL VARIABLES
    public static int score;
    public static GameObject currentRoad;
    public static float otherCarsSpeed = 75f;
    public static float otherCarsDestroyTime = 15f;
    public static bool isCarSpawnerOn = false;

    //START POSITIONS
    public static Vector3 carStartPos = new Vector3(0f, 12f, -350f);
    public static Vector3 road1StartPos = new Vector3(32f, 0f, 0f);
    public static Vector3 road2StartPos = new Vector3(32f, 0f, 3835f);    

}


