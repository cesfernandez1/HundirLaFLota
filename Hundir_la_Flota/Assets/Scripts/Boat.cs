using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boat : MonoBehaviour
{

    private int size;
    private int value;
    private string title;
    private bool added;


    public Boat(int s, int v, string t)
    {
        size = s;
        value = v;
        title = t;
    }

    public void setName(string n)
    {
        title = n;
    }

    public void setValue(int v)
    {
        value = v;
    }

    public void setSize(int s)
    {
        size = s;
    }

    public void setAdded(bool t)
    {
        added = t;
    }
}
