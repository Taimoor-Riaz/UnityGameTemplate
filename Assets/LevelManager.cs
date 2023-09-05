using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    int levelno;

    private void Start()
    {
        levelno = PlayerPrefs.GetInt("selected_level");
        levels[levelno-1].SetActive(true);
    }
}
