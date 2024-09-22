using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform primarySlot; // Hand slot
    public Transform secondarySlot; // Back slot

    public GameObject primaryObject; // Item in primary slot
    public GameObject secondaryObject; // Item in secondary slot

    public bool isPrimaryFilled;
    public bool isSecondaryFilled;

    private PlayerController pc; // Reference to PlayerController

    
    public void Start()
    {
        pc = GameManager.Instance.PlayerInstance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapSlots();
        }
    }

    public void EquipItem(GameObject weaponPrefab)
    {
        if (weaponPrefab == null)
        {
            Debug.LogError("Weapon prefab is null.");
            return; // Exit if the weapon prefab is null
        }
        if (!isPrimaryFilled)
        {
            // Equip item into primary slot
            GameObject itemInstance = Instantiate(weaponPrefab, primarySlot.position, primarySlot.rotation, primarySlot);
            primaryObject = itemInstance;
            isPrimaryFilled = true;

            UpdatePlayerController(primaryObject);

            Debug.Log("Item equipped in primary slot");
        }
        else if (!isSecondaryFilled)
        {
            // Equip item into secondary slot if primary is full
            GameObject itemInstance = Instantiate(weaponPrefab, secondarySlot.position, secondarySlot.rotation, secondarySlot);
            secondaryObject = itemInstance;
            isSecondaryFilled = true;

            Debug.Log("Item equipped in secondary slot");
        }
        else
        {
            Debug.Log("Both slots are filled. Cannot equip more items.");
        }
    }

    void SwapSlots()
    {
        if (primaryObject != null || secondaryObject != null)
        {
            // Swap primary and secondary items
            GameObject temp = primaryObject;
            primaryObject = secondaryObject;
            secondaryObject = temp;

            // Update their positions
            if (primaryObject != null)
            {
                primaryObject.transform.SetParent(primarySlot);
                primaryObject.transform.position = primarySlot.position;
                primaryObject.transform.rotation = primarySlot.rotation;
            }

            if (secondaryObject != null)
            {
                secondaryObject.transform.SetParent(secondarySlot);
                secondaryObject.transform.position = secondarySlot.position;
                secondaryObject.transform.rotation = secondarySlot.rotation;
            }

            // Update slot filled status
            isPrimaryFilled = primaryObject != null;
            isSecondaryFilled = secondaryObject != null;

            // Update PlayerController based on new primary item
            UpdatePlayerController(primaryObject);

            Debug.Log("Slots swapped");
        }
    }

    private void UpdatePlayerController(GameObject item)
    {
        if (item != null)
        {
            if (item.CompareTag("Gun"))
            {
                pc.canShoot = true;
                pc.canMelee = false;
            }
            else if (item.CompareTag("Axe"))
            {
                pc.canMelee = true;
                pc.canShoot = false;
            }
            else
            {
                pc.canShoot = false;
                pc.canMelee = false;
            }
        }
        else
        {
            pc.canShoot = false;
            pc.canMelee = false;
        }
    }

}
