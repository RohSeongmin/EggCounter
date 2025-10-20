using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EggList
{
    public List<Egg> eggList;
    public string eggname;
    //Boolean FastFinding;

    public EggList(List<Egg> eggList, string eggname)
    {
        this.eggList = eggList;
        this.eggname = eggname;
    }
    public string Tostring()
    {
        List<string> eggList_str = new List<string>();
        foreach (Egg egg in eggList)
        {
            eggList_str.Add(egg.Tostring());
        }
        return this.eggname+"?"+string.Join("+",eggList_str);
    }
    
}
