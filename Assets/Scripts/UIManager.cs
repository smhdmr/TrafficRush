using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Instance
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion    

    #region UI Elements
    public TMP_Text scoreText;
    public GameObject startMenu, gameOverMenu;
    #endregion
    
    public void SetGameOverMenuVisibility(bool isVisible)
    {
        gameOverMenu.SetActive(isVisible);
    }

    public void OnClickStart()
    {
        startMenu.SetActive(false);
        LevelManager.Instance.ResumeTime();
    }

    public void OnClickExit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void OnClickRestart()
    {
        SetGameOverMenuVisibility(false);
        LevelManager.Instance.RestartGame();
    }

    public void UpdateScore()
    {
        scoreText.text = Global.score.ToString();
    }

}
