using UnityEngine;

public class WarningPopup : MonoBehaviour
{
    public GameObject popup;

    public void Awake()
    {
        PopupOff();
    }
    public void PopupOn()
    {
        popup.SetActive(true);
    }
    public void PopupOff()
    {
        popup.SetActive(false);
    }
}
