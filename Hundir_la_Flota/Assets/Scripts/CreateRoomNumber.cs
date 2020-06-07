using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomNumber : MonoBehaviour
{
    public Text codeRoom;

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
