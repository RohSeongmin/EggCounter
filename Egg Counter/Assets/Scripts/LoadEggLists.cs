using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LoadEggLists : MonoBehaviour
{
    public Transform parentTransform;
    public GameObject prefab;
    void Start()
    {
        CreateButtons();
    }

    public void CreateButtons()
    {
        foreach (var egglist in DataManager.eggLists)
        {
            GameObject button = Instantiate(prefab, parentTransform);

            button.GetComponentInChildren<EggListButton>().thisEggList = egglist;
            button.GetComponentInChildren<EggListButton>().button_name.text = egglist.eggname;
        }
    }
}
