using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    [SerializeField] private float stoppingDistance = 2f; // Distance at which the enemy stops moving towards the player

    private Renderer enemyRenderer;

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //Movement

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; // Keep movement on the horizontal plane

        float distanceToPlayer = directionToPlayer.magnitude;
        directionToPlayer.Normalize();

        // Check if the player is looking at the enemy
        Vector3 playerForward = player.forward;
        playerForward.y = 0; // Keep the check on the horizontal plane

        bool isPlayerLookingAtEnemy = Vector3.Dot(playerForward, directionToPlayer) > 0.5f;

        if (!isPlayerLookingAtEnemy && distanceToPlayer > stoppingDistance)
        {
            // Move towards the player
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }

        // Face the player
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
