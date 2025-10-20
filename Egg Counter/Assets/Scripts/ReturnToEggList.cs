using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToEggList : MonoBehaviour
{
    public Scene_Changer SC;
    public void onClicked()
    {
        PlayerPrefs.SetInt("CurrentList", -1);
        PlayerPrefs.Save();
        SC.ChangeScene();
    }
}
