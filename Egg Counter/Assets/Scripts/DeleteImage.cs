using UnityEngine;
using UnityEngine.UI;
public class DeleteImage : MonoBehaviour
{
    public Image image;
    public Popup popup;
    public void DeleteImg()
    {
        image.sprite = null;
        popup.egg.image_location = null;
    }
}
