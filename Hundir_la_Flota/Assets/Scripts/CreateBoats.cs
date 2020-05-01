using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoats : MonoBehaviour
{
    public GameObject boat;
    List<GameObject> boats;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        if (boat.GetComponent<Boat>() == null)
            Debug.Log("Boat object need to have boat script attached");

        CreateNavy();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateNavy()
    {
        boats = new List<GameObject>();
        SpawnBoats();
    }

    private void SpawnBoats()
    {
        for(int i=0; i<4; i++)
        {
            boats.Add(Instantiate(boat) as GameObject);
        }
    }

}
