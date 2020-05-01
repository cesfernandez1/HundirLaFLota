using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownBoats : MonoBehaviour
{

    public Dropdown dropdown;
    List<string> boats;

    Boat[] myBoat = new Boat[8];
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
        boats = new List<string>() { "Lancha (1 casilla)" ,"Lancha (1 casilla)","Lancha (1 casilla)","Buque (2 casillas)", "Buque (2 casillas)", "Submarino (3 casillas)", "Submarino (3 casillas)", "Portaaviones (5 casillas)" };
        dropdown.AddOptions(boats);
    }

    public void getValue()
    {
        int n = 0;
         //Debug.Log(boats[dropdown.value]);

        if(boats[dropdown.value].Equals("Lancha (1 casilla)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Lancha (1 casilla)");
            dropdown.AddOptions(boats);
            myBoat[n] = new Boat(1,1,"Lancha");
            n++;
        }else if(boats[dropdown.value].Equals("Buque (2 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Buque (2 casillas)");
            dropdown.AddOptions(boats);
        }else if(boats[dropdown.value].Equals("Submarino (3 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Submarino (3 casillas)");
            dropdown.AddOptions(boats);
        }
        else if(boats[dropdown.value].Equals("Portaaviones (5 casillas)"))
        {
            dropdown.ClearOptions();
            boats.Remove("Portaaviones (5 casillas)");
            dropdown.AddOptions(boats);
        }
    }


}
