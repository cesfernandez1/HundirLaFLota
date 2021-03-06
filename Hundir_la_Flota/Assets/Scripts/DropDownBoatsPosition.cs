﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownBoatsPosition : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        FillDropdownPosition();
    }

    void FillDropdownPosition()
    {
        List<string> positions = new List<string>() { "Horizontal ►" , "Vertical ▼" };
        dropdown.AddOptions(positions);
    }
}
