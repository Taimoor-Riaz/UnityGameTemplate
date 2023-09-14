using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image loadingBar;
    private void Start()
    {
        StartCoroutine(LoadingScene()); 
    }

    IEnumerator LoadingScene()
    {
        yield return null;
    
        AsyncOperation async = SceneManager.LoadSceneAsync("GameScene");
        async.allowSceneActivation = true;

        while (!async.isDone)
        {
            loadingBar.fillAmount = async.progress * 3f;
            yield return null;
        }

    }

}
