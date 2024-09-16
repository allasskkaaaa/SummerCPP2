using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy Variables
    [SerializeField] private float detectionRadius = 10;
    [SerializeField] private int shootSpeed = 3;

    //Reference Variables
    [SerializeField] private Transform player;


    public void shoot()
    {

    }
}


/*
    [SerializeField] private Transform player; // Reference to the player
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

        if (player == null )
        {
            PlayerController playerInstance = GameManager.Instance.PlayerInstance;
            player = playerInstance.transform;
        }
        

        InvokeRepeating("Shoot", 2, shootSpeed);
    }

    void Update()
    {
        
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
    }*/