using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    public Canvas PopupCanvas;
    public Canvas PlayerControls;

    public GameObject levelstartPopup;
    public GameObject levelSuccessPopup;
    public GameObject pausePopup;

    private void Awake()
    {
        instance = this;
    }

    public void HideGui()
    {
       PlayerControls.enabled = true;
       PopupCanvas.enabled = false;   
    }

    public void ShowGui()
    {
        PlayerControls.enabled = false;
        PopupCanvas.enabled = true;
    }

}
