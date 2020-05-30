using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatsStateController : MonoBehaviour
{

    private int boatsSunken = 0;
    private int boatsSunkenPC = 0;

    public Text txtBoatsSunken;
    public Text txtBoatsSunkenPC;
    // Start is called before the first frame update
    void Start()
    {
        txtBoatsSunkenPC.text = boatsSunkenPC.ToString();
        txtBoatsSunken.text = boatsSunken.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reload()
    {
        txtBoatsSunken.text = boatsSunken.ToString();
        txtBoatsSunkenPC.text = boatsSunkenPC.ToString();
    }

    public void addBoatSunken()
    {
        boatsSunken += 1;
        Reload();
    }

    public void addBoatSunkenPC()
    {
        boatsSunkenPC += 1;
        Reload();
    }

    public int getBoats()
    {
        return boatsSunken;
    }

    public int getBoatsPC()
    {
        return boatsSunkenPC;
    }

    public void deleteData()
    {
        boatsSunken = 0;
        boatsSunkenPC = 0;
    }
}
