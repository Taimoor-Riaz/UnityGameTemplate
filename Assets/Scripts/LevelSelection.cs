using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public GameObject container;
     int num;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selected_level"))
        {
            PlayerPrefs.SetInt("selected_level", 1);
            PlayerPrefs.SetInt("unlock_Level", 1);
        }
     
        for (int i = 0; i < container.transform.childCount; i++)
        {
          
            if(i >= PlayerPrefs.GetInt("unlock_Level"))
            {            
                container.transform.GetChild(i).GetComponent<Button>().interactable = false;

            }
        }
       
    }


    public void LevelSelected(int index)
    {
        PlayerPrefs.SetInt("selected_level",index);
        SceneManager.LoadScene("Loading");
    }
}
