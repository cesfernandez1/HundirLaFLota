using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownBoats : MonoBehaviour
{

    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        FillBoatList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillBoatList()
    {
        List<string> boats = new List<string>() { "Lancha (1 casilla)" , "Submarino (3 casillas)" , "Buque (2 casillas)" , "Portaaviones (5 casillas)"};
        dropdown.AddOptions(boats);
    }


}
