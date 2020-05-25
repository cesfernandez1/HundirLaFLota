using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boat
{

    private int size;
    private int value;
    private string title;
    private bool added;
    private int id;
    private int[] position;
    private int impacts;
    private bool sunken = false;


    public Boat(int s, int v, string t, int i)
    {
        size = s;
        value = v;
        title = t;
        id = i;
    }

    public Boat()
    {
        size = 0;
        value = 0;
        title = "Vacio";
        id = -1;
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
        return title;
    }

    public int getValue()
    {
        return value;
    }

    public void setID(int i)
    {
        id = i;
    }

    public int[] getPosition()
    {
        return position;
    }

    public int getImpacts()
    {
        return impacts;
    }

    public void setImpact()
    {
        impacts += 1;
    }

    public bool isSunken()
    {
        if (impacts == (size * size))
            return true;
        return false;
    }

    public int getID()
    {
        return id;
    }
}


