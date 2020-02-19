using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerOptionsScreen : MonoBehaviour
{

    public GameObject ModesMenuScreen;
    public GameObject JoinRoomScreen;
    public GameObject CreateRoomScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JoinRoomMenu()
    {
        this.JoinRoomScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void CreateRoomMenu()
    {
        this.gameObject.SetActive(false);
        CreateRoomScreen.SetActive(true);
    }

    public void BackModesMenu()
    {
        this.gameObject.SetActive(false);
        ModesMenuScreen.SetActive(true);
    }
}
