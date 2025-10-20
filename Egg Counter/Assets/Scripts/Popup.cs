using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Toggle toggle;
    public TMP_InputField memo;
    public TMP_Text Date;
    public Button image;

    public bool ifused = false;
    public Egg egg;
    public void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        memo = GetComponentInChildren<TMP_InputField>();
        Date = GetComponentInChildren<TMP_Text>();
        image = GetComponentInChildren<Button>();
    }
    public void setting()
    {
        if (egg.used)
        {
            toggle.isOn = true;
            ifused = true;
            Date.text = egg.when;
            //image.image.sprite = 
        }
        else { 
            toggle.isOn = false;
            ifused = false;
            Date.text = ""; 
            //image.image.sprite
        }

        memo.text = egg.memo;

        toggle.onValueChanged.AddListener(used);
    }
    public void used(bool isOn)
    {
        ifused = isOn;
        if (isOn)
        {
            Date.text = DateTime.Now.ToString("yyyy-MM-dd | HH:mm");
        }
        else
        {
            Date.text = "";
        }
    }
    public void save()
    {
        egg.used = ifused;
        egg.memo = memo.text;
        egg.when = Date.text;
        //egg.image_location = ;
    }
}
