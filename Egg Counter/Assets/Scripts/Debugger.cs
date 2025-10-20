using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public bool debug = false;

    void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                DataManager.eggLists.Clear();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(DataManager.eggLists.Count);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                DataManager.SaveData();
            }
        }
    }
}
