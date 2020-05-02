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
    private int id;
    private int[] position;


    public Boat(int s, int v, string t, int i)
    {
        size = s;
        value = v;
        title = t;
        id = i;
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

    public void setPosition(int x, int y)
    {
        position[0] = x;
        position[1] = y;
    }

    public int getSize()
    {
        return size;
    }

    public string getName()
    {
        return name;
    }

    public int getValue()
    {
        return value;
    }

    public int[] getPosition()
    {
        return position;
    }
}


