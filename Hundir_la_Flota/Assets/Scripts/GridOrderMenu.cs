using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridOrderMenu : MonoBehaviour
{

    public GameObject modesMenuScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void backMenu()
    {
        this.gameObject.GetComponent<Grid>().deleteGrid();
        this.gameObject.GetComponent<GridPC>().deleteGrid();
        this.gameObject.GetComponent<AddBoats>().removeData();
        this.gameObject.SetActive(false);
        modesMenuScreen.SetActive(true);
    }
}
