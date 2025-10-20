using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg
{
    public int index;
    public bool used;
    public string memo;
    public string when;
    public string image_location;

    public Egg(int i, bool used, string memo, string when, string image_location)
    {
        this.index = i;
        this.used = used;
        this.memo = memo;
        this.when = when;
        this.image_location = image_location;
    }
    public string Tostring()
    {
        return this.index.ToString() + "," + used.ToString() + "," + this.memo + "," + this.when + "," + this.image_location;
    }
}
