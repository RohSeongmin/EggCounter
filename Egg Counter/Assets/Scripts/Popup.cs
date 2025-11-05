using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Toggle toggle;
    public TMP_InputField memo;
    public TMP_Text Date;
    public Button image;
    public Sprite nll;

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
        }
        else { 
            toggle.isOn = false;
            ifused = false;
            Date.text = "";
        }

        if (egg.image_location != null)
        {
            LoadSavedPhoto(egg.image_location);
        }
        else
        {
            image.image.sprite = nll;
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
        //egg.image_location;

        Debug.Log(egg.image_location);
    }
    public void TakePhoto()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (path == null) return;
            Texture2D texture = NativeGallery.LoadImageAtPath(path, 2048);
            if (texture == null) return;

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            image.image.sprite = sprite;
            image.image.preserveAspect = true;

            RectTransform rt = image.GetComponent<RectTransform>(); //image.image
            float aspect = (float)texture.width / texture.height;
            rt.sizeDelta = new Vector2(rt.sizeDelta.y * aspect, rt.sizeDelta.y);

            egg.image_location = path;
            Debug.Log(egg.image_location);
        });
    }
    public void LoadSavedPhoto(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            image.image.sprite = nll;
            return;
        }

        Texture2D texture = NativeGallery.LoadImageAtPath(path, 2048);
        if (texture == null)
        {
            image.image.sprite = nll;
            return;
        }

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        image.image.sprite = sprite;
        image.image.preserveAspect = true;
    }
}
