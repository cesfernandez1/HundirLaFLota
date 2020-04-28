using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitInputChar : MonoBehaviour
{

    public InputField inputRows;
    public InputField inputCols;
    // Start is called before the first frame update
    void Start()
    {
        inputCols.characterLimit = 2;
        inputRows.characterLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
