using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    #region Instance
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
    }
    #endregion

    [Header("LEVEL OBJECT TRANSFORMS")]
    public Transform car;
    public Transform road1;
    public Transform road2;


    public void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        CarSpawner.Instance.DestroyActiveCars();
        car.position = Global.carStartPos;
        road1.position = Global.road1StartPos;
        road2.position = Global.road2StartPos;
        Global.score = 0;
        UIManager.Instance.UpdateScore();
        ResumeTime();
        Global.isCarSpawnerOn = true;
    }

    public void GameOver()
    {
        Global.isCarSpawnerOn = false;
        FreezeTime();
        UIManager.Instance.SetGameOverMenuVisibility(true);
    }
}
