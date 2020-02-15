using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject modesMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        modesMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        this.gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }


    public void CloseGame()
    {
        Application.Quit();
    }
}
