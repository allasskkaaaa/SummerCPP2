using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10;
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private int speed = 7;
    private bool isOccupied = false;

    //Reference Variables
    [SerializeField] private Transform player;

    Animator anim;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isOccupied)
        NPC_Follow();
    }

    private void NPC_Follow()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRadius)
        {
            //Follows player when player is a certain distance away

            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;  // Ignore vertical rotation

            // Create a rotation that looks in the direction of the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Apply the rotation
            transform.rotation = targetRotation;

            //transform.LookAt(other.transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isOccupied = true;

            anim.SetBool("attack",true);

            //face enemy and shoot. It will prioritize attacking an enemy over following the player.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("attack", false);
    }

}
