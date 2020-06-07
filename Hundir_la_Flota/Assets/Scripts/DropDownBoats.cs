using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownBoats : MonoBehaviour
{

    public Dropdown dropdown;
    private List<string> boats = new List<string>() { "Lancha (1 casilla)", "Lancha (1 casilla)", "Lancha (1 casilla)",
                                                      "Buque (2 casillas)", "Buque (2 casillas)",
                                                      "Submarino (3 casillas)", "Submarino (3 casillas)",
                                                      "Portaaviones (5 casillas)" };

    public void FillBoatList()
    {
        dropdown.ClearOptions();
        boats = new List<string>() { "Lancha (1 casilla)", "Lancha (1 casilla)", "Lancha (1 casilla)",
                                     "Buque (2 casillas)", "Buque (2 casillas)",
                                     "Submarino (3 casillas)", "Submarino (3 casillas)",
                                     "Portaaviones (5 casillas)" };
        dropdown.AddOptions(boats);
    }

    public void getValue(string boat)
    {
        if (boat.Equals("Lancha (1 casilla)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Lancha (1 casilla)");
            dropdown.AddOptions(boats);
        }
        else if (boat.Equals("Buque (2 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Buque (2 casillas)");
            dropdown.AddOptions(boats);
        }
        else if (boat.Equals("Submarino (3 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Submarino (3 casillas)");
            dropdown.AddOptions(boats);
        }
        else if (boat.Equals("Portaaviones (5 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Portaaviones (5 casillas)");
            dropdown.AddOptions(boats);
        }
    }

    public void updateDropDown()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(boats);
    }


}
