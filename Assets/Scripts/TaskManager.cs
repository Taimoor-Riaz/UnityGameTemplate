using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public Transform playerPosition;
    public GameObject player;
    public GameObject Cutscene;
    public bool isCutscene;
    public float cutscenetime;
    public Animator playerAnimator;




    public bool UseTimer;
    public float LevelTime;
    public int seconds;
    public int minute;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (isCutscene)
        {
            StartCoroutine(StartCutscene());
        }
        else
        {

            player.transform.position = playerPosition.position;
            GUIManager.instance.levelstartPopup.SetActive(true);
            GUIManager.instance.ShowGui();
        }

    }


    private void Update()
    {
        if(UseTimer)
        {
            LevelTime -= Time.deltaTime;
            seconds = (int)LevelTime % 60;
            minute = (int)LevelTime / 60;
           if(seconds>=10)
            {
               
                GUIManager.instance.TimerText.text = " 0" + minute + " : " + seconds;
            }
            else
            {
                GUIManager.instance.TimerText.text = " 0" + minute + " : 0" + seconds;
            }

            if(LevelTime<=0)
            {
                UseTimer = false;
                GameManager.instance.Fail();

            }

        }
        
    }


    IEnumerator StartCutscene()
    {
        Cutscene.SetActive(true);
        yield return new WaitForSeconds(cutscenetime);
        Cutscene.SetActive(false);
        player.transform.position = playerPosition.position;
        GUIManager.instance.levelstartPopup.SetActive(true);
        GUIManager.instance.ShowGui();
    }



}
