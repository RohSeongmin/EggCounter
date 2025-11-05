using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public TMP_Dropdown dd;
    public string[] language;

    [System.Serializable]
    public struct language_list
    {
        public TMP_Text text;
        public string[] text_lang;
        public int[] font_size;
    }
    [Header("Text Lists")]
    public language_list[] LL;


    private void Awake()
    {   if(dd != null)
        {
            dd.options.Clear();
            foreach (string lang in language)
            {
                TMP_Dropdown.OptionData lan = new TMP_Dropdown.OptionData();
                lan.text = lang;
                dd.options.Add(lan);
            }
            int cur = PlayerPrefs.GetInt("Language");
            dd.value = cur;
            languageChange(cur);
            dd.onValueChanged.AddListener(languageChange);
        }
        else
        {
            languageChange(PlayerPrefs.GetInt("Language"));
        }
    }

    public void languageChange(int n)
    {
        PlayerPrefs.SetInt("Language", n);
        PlayerPrefs.Save();
        foreach (language_list L in LL)
        {
            L.text.text = L.text_lang[n];
            L.text.fontSize = L.font_size[n];
        }
    }
}
