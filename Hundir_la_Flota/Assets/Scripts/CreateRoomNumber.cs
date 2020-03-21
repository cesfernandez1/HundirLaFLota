using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomNumber : MonoBehaviour
{
    public Text codeRoom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNumber()
    {
        string name = "";

        name += RandomNumber(name);

        codeRoom.text = name;
    }

    public string RandomNumber(string code)
    {
        System.Random rnd = new System.Random();

        code += "#";

        for(int i=0; i<5; i++)
        {
            code += rnd.Next(0, 10);
        }
        return code;
    }
}
