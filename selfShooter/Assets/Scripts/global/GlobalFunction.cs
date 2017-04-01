using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalFunction
{
    public static void ExitGame()
    {
        Application.Quit();
    }

    public static void LoadScene(string sceneName)
    {
        GlobalData.playerScore = 0;
        GlobalData.isUI = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public static void OnHardLevelChange()
    {
        int hardLevel = GlobalData.hardLevel;
        GlobalData._enemyInitTime = GlobalData.enemyInitTime[hardLevel];
        GlobalData._enemyWaveNum = GlobalData.enemyWaveNum[hardLevel];
        GlobalData._enemyBlood = GlobalData.enemyBlood[hardLevel];
    }
}