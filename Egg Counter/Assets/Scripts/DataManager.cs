using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static List<EggList> eggLists;
    public Scene_Changer SC;
    private void Awake()
    {
        eggLists = LoadData();
        
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("CurrentList") >= 0){
            SC.SceneName = "Eggs";
            SC.ChangeScene();
        }
        else
        {
            SC.SceneName = "EggLists";
            SC.ChangeScene();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public static void SaveData()
    {
        List<string> eggList_str = new List<string>();
        foreach (var eggList in eggLists)
        {
            eggList_str.Add(eggList.Tostring());
        }
        string eggList_forsave = string.Join(";", eggList_str);
        Debug.Log(eggList_forsave);
        PlayerPrefs.SetString("EggData", eggList_forsave);
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveData();
    }

    public List<EggList> LoadData()
    {
        List<EggList> eggLists = new List<EggList>();
        string[] eggList_str;
        string eggList_forload = PlayerPrefs.GetString("EggData");
        if (eggList_forload == null || eggList_forload == "") { PlayerPrefs.SetInt("CurrentList", -1);  return eggLists; }
        eggList_str = eggList_forload.Split(';');
        foreach (var aneggList in eggList_str)
        {
            string[] data = aneggList.Split('?');
            string eggname = data[0];
            List<Egg> eggList = new List<Egg>();
            foreach (var anegg in data[1].Split('+'))
            {
                string[] data2 = anegg.Split(',');
                int index = int.Parse(data2[0]);
                bool used = bool.Parse(data2[1]);
                string memo = data2[2];
                string when = data2[3];
                string image_location = data2[4];
                eggList.Add(new Egg(index, used, memo, when, image_location));

            }
            eggLists.Add(new EggList(eggList, eggname));
        }
        return eggLists;
    }

}
