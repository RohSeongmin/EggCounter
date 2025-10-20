using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Popup popup;
    public Button popupCloser;
    public void Awake()
    {
        popup.gameObject.SetActive(false);
        popupCloser.gameObject.SetActive(false);
    }

    public void PopupOn(Egg egg)
    {
        popupCloser.gameObject.SetActive(true);
        popup.gameObject.SetActive(true);
        popup.egg = egg;
        popup.setting();
    }
}
