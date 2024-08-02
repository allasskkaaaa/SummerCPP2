using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Material ogMaterial; // Original material
    [SerializeField] Material transMaterial; // Transparent Material
    [SerializeField] Camera viewCamera; // Reference to the camera
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private Transform raycastOrigin; // Reference to the game object for raycasting
    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    [SerializeField] private float stoppingDistance = 2f; // Distance at which the enemy stops moving towards the player
    public float shootSpeed = 5.0f;

    private Renderer enemyRenderer;
    private Animator anim;
    private bool isPlayerFacing;

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        enemyRenderer.material = ogMaterial;

        InvokeRepeating("Shoot", 2, shootSpeed);
    }

    void Update()
    {
        // Check if player is looking at the enemy
        isPlayerFacing = IsPlayerLookingAtEnemy();

        // Control shooting and movement based on whether the player is facing the enemy
        if (isPlayerFacing)
        {
            CancelInvoke("Shoot");
            enemyRenderer.material = ogMaterial;
        }
        else
        {
            if (!IsInvoking("Shoot"))
            {
                InvokeRepeating("Shoot", 2, shootSpeed);
            }
            enemyRenderer.material = transMaterial;
            MoveTowardsPlayer();
        }
    }

    private bool IsPlayerLookingAtEnemy()
    {
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                Debug.Log("Player is looking at enemy");
                return true;
            }
        }
        Debug.Log("Player is not looking at enemy");
        return false;
    }

    private void MoveTowardsPlayer()
    {

            // Calculate direction to player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;

            // Move towards the player if the distance is greater than stoppingDistance
            if (directionToPlayer.magnitude > stoppingDistance)
            {
                Vector3 moveDirection = directionToPlayer.normalized * moveSpeed * Time.deltaTime;
                transform.position += moveDirection;
            }

            // Face the player
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

        
    }

    public void Shoot()
    {
        anim.SetTrigger("Attack");
    }
}
