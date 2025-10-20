using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCloser : MonoBehaviour
{
    public GameObject popup;
    public GameObject spawner;
    public void Onclicked()
    {
        popup.GetComponentInChildren<Popup>().save();
        popup.SetActive(false);
        spawner.GetComponentInChildren<LoadEggs>().CreateEggs();
        this.gameObject.SetActive(false);
    }
}
