using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform primarySlot; // Hand slot
    public Transform secondarySlot; // Back slot

    public GameObject primaryObject; // Item in primary slot
    public GameObject secondaryObject; // Item in secondary slot

    public bool isPrimaryFilled = false;
    public bool isSecondaryFilled = false;

    private PlayerController pc; // Reference to PlayerController

    public void Start()
    {
        pc = FindObjectOfType<PlayerController>();
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

    public void SaveInventory()
    {
        SaveSystem.SaveInventory(this);
    }

    public void LoadInventory()
    {
        InventoryData data = SaveSystem.LoadInventory();

        isPrimaryFilled = data.isPrimaryFilled;
        isSecondaryFilled = data.isSecondaryFilled;

        // Destroy current objects in slots before loading new ones
        if (primaryObject != null)
        {
            Destroy(primaryObject);
        }
        if (secondaryObject != null)
        {
            Destroy(secondaryObject);
        }

        // Load and instantiate the saved primary object
        if (isPrimaryFilled)
        {
            GameObject primaryPrefab = Resources.Load<GameObject>(data.primaryObjectName);
            if (primaryPrefab != null)
            {
                primaryObject = Instantiate(primaryPrefab, primarySlot.position, primarySlot.rotation, primarySlot);

                // Set position and rotation for the primary object
                primaryObject.transform.position = new Vector3(data.primaryObjectPos[0], data.primaryObjectPos[1], data.primaryObjectPos[2]);
                primaryObject.transform.rotation = new Quaternion(data.primaryObjectRot[0], data.primaryObjectRot[1], data.primaryObjectRot[2], data.primaryObjectRot[3]);

                // Update the PlayerController based on the primary object
                UpdatePlayerController(primaryObject);
            }
        }

        // Load and instantiate the saved secondary object
        if (isSecondaryFilled)
        {
            GameObject secondaryPrefab = Resources.Load<GameObject>(data.secondaryObjectName);
            if (secondaryPrefab != null)
            {
                secondaryObject = Instantiate(secondaryPrefab, secondarySlot.position, secondarySlot.rotation, secondarySlot);

                // Set position and rotation for the secondary object
                secondaryObject.transform.position = new Vector3(data.secondaryObjectPos[0], data.secondaryObjectPos[1], data.secondaryObjectPos[2]);
                secondaryObject.transform.rotation = new Quaternion(data.secondaryObjectRot[0], data.secondaryObjectRot[1], data.secondaryObjectRot[2], data.secondaryObjectRot[3]);
            }
        }

        Debug.Log("Inventory loaded successfully.");
    }

}
