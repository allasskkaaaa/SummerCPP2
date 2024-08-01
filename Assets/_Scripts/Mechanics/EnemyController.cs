using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    [SerializeField] private float stoppingDistance = 2f; // Distance at which the enemy stops moving towards the player
    public float shootSpeed = 5.0f;
    private float timer;

    private Renderer enemyRenderer;
    private Animator anim;

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
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

        timer += Time.deltaTime;
        if (timer >= shootSpeed)
        {
            
            timer = 0f;
            anim.SetTrigger("Attack");
            Debug.Log("Shoot");
        }

    }
}
