using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contro : MonoBehaviour
{
    private bool inventoryEnabled;

    public GameObject inventory;

    private int allSlots;

    private int enabledSlots;

    private GameObject[] slot;

    public GameObject Estanteria;

    void Start()
    {
        allSlots = Estanteria.transform.childCount;

        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++) 
        {
            slot[i] = Estanteria.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        { 
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else 
        { 
            inventory.SetActive(false);
        }
    }
}
