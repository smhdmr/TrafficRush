using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Start Screen Buttons
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
    #endregion

}
