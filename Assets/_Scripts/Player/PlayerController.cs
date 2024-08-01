using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Camera playerCamera; // Reference to the camera
    CharacterController cc;

    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        gravity = Physics.gravity.y;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // Get the camera's forward and right directions
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        // Make sure the directions are on the same plane as the player
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the move direction relative to the camera
        Vector3 moveDirection = (cameraForward * vInput + cameraRight * hInput).normalized;
        moveDirection *= speed;

        if (moveDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        moveDirection.y = gravity;
        moveDirection *= Time.deltaTime;

        cc.Move(moveDirection);
    }
}
