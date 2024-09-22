using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game data has been saved.");
            GameManager.Instance.SaveGameManager();
            GameManager.Instance.SaveNPCs();
            other.gameObject.GetComponent<PlayerController>().SavePlayer();
            //other.gameObject.GetComponent<InventoryManager>().SaveInventory(); 
        }
    }
}
