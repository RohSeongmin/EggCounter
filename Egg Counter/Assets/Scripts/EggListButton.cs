using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggListButton : MonoBehaviour
{
    public EggList thisEggList;
    public Scene_Changer SC;
    public TMP_Text button_name;
    
    public void OnClicked()
    {
        PlayerPrefs.SetInt("CurrentList", DataManager.eggLists.IndexOf(thisEggList));
        SC.ChangeScene();
    }
}
