using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public void GameStart()
    {
        GUIManager.instance.levelstartPopup.SetActive(false);
        GUIManager.instance.HideGui();
    }

    public void GamePause() 
    {
        GUIManager.instance.pausePopup.SetActive(true);
        GUIManager.instance.ShowGui();
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading");
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume() 
    {
        GUIManager.instance.pausePopup.SetActive(false);
        GUIManager.instance.HideGui();
        Time.timeScale = 1;

    }
    public void Fail()
    {
        GUIManager.instance.levelFail.SetActive(true);
        GUIManager.instance.ShowGui();
        Time.timeScale = 0;

    }

    public void Success()
    {
        GUIManager.instance.levelSuccessPopup.SetActive(true);
        GUIManager.instance.ShowGui();
        Time.timeScale = 0;

    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("unlock_Level", PlayerPrefs.GetInt("unlock_Level") + 1);
        SceneManager.LoadScene("LevelSelection");
    }
}
