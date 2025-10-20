using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewEggList : MonoBehaviour
{
    public Scene_Changer SC;
    public TMP_InputField nameInput;
    public TMP_InputField numberInput;
    public TMP_Text nameInputWarning;
    public TMP_Text numberInputWarning;

    private bool validName = false;
    private bool validNum = false;
    private void Awake()
    {
        nameInputWarning.gameObject.SetActive(false);
        numberInputWarning.gameObject.SetActive(false);
        validName = false;
        validNum = false;
    }

    public void OnClicked()
    {
        CheckName(nameInput.text);
        CheckNumber(numberInput.text);
        if (validName && validNum)
        {
            SaveNewEggList();
            SC.ChangeScene();
        }
    }

    public void CheckName(string input)
    {
        if (input == "" || input == " ")
        {
            nameInputWarning.text = "Please input the name of an EggList";
            nameInputWarning.gameObject.SetActive(true);
            validName = false;
        }
        else
        {
            nameInputWarning.gameObject.SetActive(false);
            validName = true;
        }
    }

    public void CheckNumber(string inputstring)
    {
        int.TryParse(inputstring, out int input);
        
        if (input <= 0)
        {
            numberInputWarning.text = "Please set the correct number of eggs";
            numberInputWarning.gameObject.SetActive(true);
            validNum = false;
        }
        else if(input > 30)
        {
            numberInputWarning.text = "The maximum number is 30";
            numberInputWarning.gameObject.SetActive(true);
            validNum = false;
        }
        else
        {
            numberInputWarning.gameObject.SetActive(false);
            validNum = true;
        }
    }
    
    public void SaveNewEggList()
    {
        List<Egg> list = new List<Egg>();
        for(int i = 0; i < int.Parse(numberInput.text); i++)
        {
            Egg newEgg = new Egg(i, false, null, null, null);
            list.Add(newEgg);
        }
                
        EggList newEggList = new EggList(list, nameInput.text);
        DataManager.eggLists.Add(newEggList);

        PlayerPrefs.SetInt("CurrentList", DataManager.eggLists.IndexOf(newEggList));
        PlayerPrefs.Save();
    }

}
