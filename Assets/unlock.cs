using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Unlocklevel()
    {

        int num = PlayerPrefs.GetInt("unlock_Level");
        num++;
        PlayerPrefs.SetInt("unlock_Level", num);
    }
}
