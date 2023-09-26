using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Checkpoint { Simple, CutScene, SetActive, animation, waiting,ObjectiveDone}
public enum TriggerObject {Player,Vehicle}

[System.Serializable]
public struct SetObjectActive
{
    public GameObject objectToActive;
    public bool state;
};


public class CheckPointManager : MonoBehaviour
{
    public Checkpoint checkpoint;
    public TriggerObject triggerObject;
   

    [Header("CheckPoint Properties")]
    public bool AutoAction;
    public bool PositionToCheckPoint;
    public bool RotationToCheckPoint;
    private Collider OtherCollider;

    [Header("Objects To Active")]
    public SetObjectActive[] objects;

    [Header("Waiting Properties")]
    public float waitTime;

    [Header("CutSCene Properties")]
    public GameObject InGameCutscene;
    public float cutsceneTime;

    [Header("Animation Properties")]
    public string animationName;

    public string parameterName;
    public bool   parameterValue;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && triggerObject == TriggerObject.Player)
        {
            OtherCollider = other;
            Triggered();
        }
    }

    public void Triggered()
    {
        if (AutoAction)
        {
            PerformAction();
        }
        else
        {
            // Ik button active karein gye r us ke click per performaction wala function call karein gye
        }
    }

    public void PerformAction()
    {
        switch(checkpoint)
        {
            case Checkpoint.Simple:
                StartCoroutine(SimpleTask());
                break;
            case Checkpoint.SetActive:
                ActiveObjects();
                break;
            case Checkpoint.animation:
                StartCoroutine(AnimationPlay());
                break;
            case Checkpoint.CutScene:
                StartCoroutine(PlayCutscene());
                break;
            case Checkpoint.waiting:
                StartCoroutine(WaitTime());
                break;
            case Checkpoint.ObjectiveDone:
                break;
        }
    }

    IEnumerator SimpleTask()
    {
        if(PositionToCheckPoint)
        {
            OtherCollider.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            yield return new WaitForSeconds(0.5f);
        }
        if(RotationToCheckPoint)
        {
            OtherCollider.transform.rotation = this.transform.rotation;
            yield return new WaitForSeconds(0.2f);
        }
        ActiveNextCheckPoint();
    }

    public void ActiveObjects()
    {
        foreach (SetObjectActive setObject in objects)
        {
            setObject.objectToActive.SetActive(setObject.state);
        }
        //for(int i=0;i<objects.Length;i++)
        //{
        //    objects[i].objectToActive.SetActive(objects[i].state);
        //}
        ActiveNextCheckPoint();

    }


    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        ActiveNextCheckPoint();
    }

    IEnumerator PlayCutscene()
    {
        InGameCutscene.SetActive(true);
        yield return new WaitForSeconds(cutsceneTime);
        InGameCutscene.SetActive(false);
        ActiveNextCheckPoint();
    }


    IEnumerator AnimationPlay()
    {
        Debug.Log("Enter here");
        yield return new WaitForSeconds(0);
        if (parameterName != "")
        {
            TaskManager.instance.playerAnimator.SetBool(parameterName, parameterValue);
        }
        else
        {
            TaskManager.instance.playerAnimator.CrossFadeInFixedTime(animationName, 0.1f);
        }
        ActiveNextCheckPoint();
    }


    public void ActiveNextCheckPoint()
    {
        if(gameObject.transform.parent.childCount>1)
        {
            gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
