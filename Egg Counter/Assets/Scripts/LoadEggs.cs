using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadEggs : MonoBehaviour
{
    EggList egglist;
    public GameObject prefab;
    public Transform ParentTransform;
    public TMP_Text title;
    void Awake()
    {
        int id = PlayerPrefs.GetInt("CurrentList");
        egglist = DataManager.eggLists[id];
        title.text = egglist.eggname;
    }

    private void Start()
    {
        CreateEggs();
    }

    public void CreateEggs()
    {
        foreach (Transform child in ParentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Egg egg in egglist.eggList)
        {
            GameObject button = Instantiate(prefab, ParentTransform);
            EggButton eggbutton = button.GetComponentInChildren<EggButton>();
            eggbutton.egg = egg;
            eggbutton.updateIcon();
        }
    }


}
