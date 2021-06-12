using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    #region Instance
    public static ScoreController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    [Header("Score Awards")]    
    public int singleCarDetectAward;
    public int dualCarDetectAward;
        

    public void CheckAward(bool isCarDetectedL, bool isCarDetectedR)
    {
        if (isCarDetectedL && isCarDetectedR)
        {
            Global.score += dualCarDetectAward;
            UIManager.Instance.UpdateScore();
        }

        else if (isCarDetectedL || isCarDetectedR)
        {
            Global.score += singleCarDetectAward;
            UIManager.Instance.UpdateScore();
        }

    }

}
