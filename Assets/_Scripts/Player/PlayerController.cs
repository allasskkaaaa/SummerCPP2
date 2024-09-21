using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    public float rotationSpeed = 0.15f;
    private Vector2 move;
    public bool canShoot = false;
    public bool canMelee = false;

    public bool primarySlotFilled = false;
    public bool secondarySlotFilled = false;

    Animator anim;
    CharacterController characterController;
    HealthManager healthManager;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        healthManager = GetComponent<HealthManager>();
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
        SaveSystem.SavePlayer(this, healthManager);
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

    }
}
