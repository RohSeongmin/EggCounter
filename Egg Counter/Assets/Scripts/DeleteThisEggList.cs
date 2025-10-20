using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteThisEggList : MonoBehaviour
{
    public ReturnToEggList ret;
    public void Onclicked()
    {
        DataManager.eggLists.RemoveAt(PlayerPrefs.GetInt("CurrentList"));
        ret.onClicked();
    }
}
