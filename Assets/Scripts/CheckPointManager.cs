using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Checkpoint { Simple, CutScene, SetActive, animation, waiting }
public enum TriggerObject {Player,Vehicle}
public class CheckPointManager : MonoBehaviour
{
    public Checkpoint checkpoint;
    public TriggerObject triggerObject;
    public bool AutoAction;
    public bool PositionToCheckPoint;
    public bool RotationToCheckPoint;
    private Collider OtherCollider;


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
                break;
            case Checkpoint.animation:
                break;
            case Checkpoint.CutScene:
                break;
            case Checkpoint.waiting:
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

    public void ActiveNextCheckPoint()
    {
        if(gameObject.transform.parent.childCount>1)
        {
            gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
