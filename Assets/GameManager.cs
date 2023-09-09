using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public void GameStart()
    {
        GUIManager.instance.HideGui();
    }

    public void GamePause() { }

    public void Restart() { }
    public void Resume() { }

}
