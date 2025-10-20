using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EggButton : MonoBehaviour
{
    public Sprite unused;
    public Sprite used;
    public Egg egg;
    public Image image;

    public PopupManager PM;
    public void Awake()
    {
        PM=GameObject.Find("PopupManager").GetComponent<PopupManager>();
    }
    public void OnClicked()
    {
        PM.PopupOn(egg);
    }
    public void updateIcon()
    {
        if (egg.used)
        {
            image.sprite = used;
        }
        else
        {
            image.sprite= unused;
        }
    }
}
