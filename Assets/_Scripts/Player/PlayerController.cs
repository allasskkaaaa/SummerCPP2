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

    Animator anim;
    CharacterController characterController;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
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
}
