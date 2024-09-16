using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private Transform backSlot = null;
    [SerializeField] private Transform handSlot = null;

    private bool backSlotFilled = false;
    private bool handSlotFilled = false;

    // Start is called before the first frame update
    void Start()
    {
        //Checks if back slot and hand slot has been set
        if (backSlot == null)
        {
            Debug.Log("Back slot inventory not set");
        }

        if (handSlot == null)
        {
            Debug.Log("Hand slot inventory not set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void equip(GameObject weapon)
    {

    }
}
