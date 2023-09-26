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
