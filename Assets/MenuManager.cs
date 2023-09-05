using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject ExitPopup;


    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void ExitButton()
    {
        ExitPopup.SetActive(true);
    }

    public void KuitGame()
    {
        Application.Quit();
    }
}
