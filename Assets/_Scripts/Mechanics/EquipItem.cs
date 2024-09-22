using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject weaponPrefab; // Prefab to instantiate
    private InventoryManager inventoryManager; // Reference to InventoryManager

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is the one who collided with the pickup
        if (other.CompareTag("Player"))
        {
            inventoryManager = other.gameObject.GetComponent<InventoryManager>();
            // Call the PickUpItem method to add the item to the inventory
            inventoryManager.EquipItem(weaponPrefab);

            // Optionally, destroy the pickup object after it's collected
            Destroy(gameObject);
        }
    }
}
