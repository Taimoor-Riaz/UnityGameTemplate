using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject player;

    private void Start()
    {
        player.transform.position = playerPosition.position;
       // player.transform.SetPositionAndRotation(playerPosition.position, playerPosition.rotation);
    }

}
