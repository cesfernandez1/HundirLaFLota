using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownBoatsPosition : MonoBehaviour
{

    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        FillDropdownPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillDropdownPosition()
    {
        List<string> positions = new List<string>() { "Horizontal ►" , "Vertical ▼" };
        dropdown.AddOptions(positions);
    }
}
