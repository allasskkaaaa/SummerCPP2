using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    public float rotationSpeed = 0.15f;
    private Vector2 move;
    public bool canShoot = false;
    public bool canMelee = false;

    public GameObject axe;
    public GameObject gun;
    Animator anim;
    CharacterController characterController;
    public HealthManager healthManager;
    public InventoryManager inventoryManager;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = this.GetComponent<CharacterController>();
        healthManager = this.GetComponent<HealthManager>();
        inventoryManager = this.GetComponent<InventoryManager>();

        if (GameManager.Instance.loadGameData == true)
        {
            LoadPlayer();
        }
    }

    private void Update()
    {
        if (canShoot)
        {
            anim.SetBool("canShoot", true);
        } else
        {
            anim.SetBool("canShoot", false);
        }

        if (canMelee)
        {
            anim.SetBool("canMelee", true);
        } else
        {
            anim.SetBool("canMelee", false);
        }
    }

    void FixedUpdate()
    {
        movePlayer();
        UpdateAnimator();
        
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        
        if (movement.magnitude > 0.1f)
        {
            // Rotate player towards movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);

            // Move player using CharacterController.Move()
            characterController.Move(movement * speed * Time.deltaTime);
        }
    }

    private void UpdateAnimator()
    {
        // Calculate and set the speed parameter in the Animator
        float currentSpeed = new Vector3(move.x, 0f, move.y).magnitude * speed;
        anim.SetFloat("speed", currentSpeed);
    }

    public IEnumerator Speedboost(float newSpeed, float length)
    {
        float originalSpeed = speed;
        speed = newSpeed;
        yield return new WaitForSeconds(length);
        speed = originalSpeed;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, healthManager, inventoryManager);
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        GameManagerData gameManagerData = SaveSystem.LoadGameManager();

        Vector3 position;
        position.x = gameManagerData.currentCheckpointPos[0];
        position.y = gameManagerData.currentCheckpointPos[1];
        position.z = gameManagerData.currentCheckpointPos[2];
        transform.position = position;

        canShoot = data.canShoot;
        canMelee = data.canMelee;

        healthManager.health = data.health;
        healthManager.lives = data.lives;

        inventoryManager.isPrimaryFilled = data.isPrimaryFilled;
        inventoryManager.isSecondaryFilled = data.isSecondaryFilled;


        // Load and equip primary object based on saved tag
        if (data.isPrimaryFilled)
        {
            if (data.primaryObjectTag == "Axe")
            {
                inventoryManager.EquipItem(axe); // Use EquipItem to instantiate and equip the axe
                Debug.Log("Loaded primary slot to Axe");
            }
            else if (data.primaryObjectTag == "Gun")
            {
                inventoryManager.EquipItem(gun); // Use EquipItem to instantiate and equip the gun
                Debug.Log("Loaded primary slot to Gun");
            }
            else
            {
                Debug.LogWarning("Object tag does not match any of the prefabs");
            }
        }
        else
        {
            Debug.Log("Primary slot saved as empty");
        }

        // Load and equip secondary object based on saved tag
        if (data.isSecondaryFilled)
        {
            if (data.secondaryObjectTag == axe.tag)
            {
                inventoryManager.EquipItem(axe); // Use EquipItem to instantiate and equip the axe in the secondary slot
                Debug.Log("Loaded secondary slot to Axe");
            }
            else if (data.secondaryObjectTag == gun.tag)
            {
                inventoryManager.EquipItem(gun); // Use EquipItem to instantiate and equip the gun in the secondary slot
                Debug.Log("Loaded secondary slot to Axe");
            }
            else
            {
                Debug.Log("Object tag does not match any of the prefabs");
            }
        }
        else
        {
            Debug.Log("Secondary slot saved as empty");
        }
    }
}
