using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] public float detectionRadius = 10;
    [SerializeField] public int attackSpeed = 3;
    [SerializeField] public int speed = 7;
    [SerializeField] public float followSpeed = 4f;
    [SerializeField] public float stoppingDistance = 2f;
    [SerializeField] public float catchUpSpeed = 8f;
    [SerializeField] public float catchUpDistance = 12f;
    private bool isOccupied = false;
    private Vector3 lastPosition;

    // Reference Variables
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    Animator anim;
    HealthManager healthManager;

    private void Start()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerInstance.transform;
        }
        else
        {
            target = player;
        }

        anim = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerInstance.transform;
        }
        else
        {
            target = player;
        }

        if (!isOccupied) // Only follow if not occupied by combat
        {
            follow(target);
        }
        UpdateAnimator();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (target != other.transform) // Only change target if it's not already the enemy
            {
                target = other.transform;
                follow(target);
                Debug.Log("Enemy detected. Switching target.");
                isOccupied = true; // NPC is now occupied with combat
                AttackEnemy();
            }

            /*if (Vector3.Distance(transform.position, target.position) <= stoppingDistance)
            {
                // Trigger attack
                
            }*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Stops attacking and switches back to the player
            anim.SetBool("attack", false);
            isOccupied = false;
            target = player;
            follow(target);
            Debug.Log("Enemy left the radius. Returning to follow player.");
        }
    }

    public void follow(Transform target)
    {
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude > stoppingDistance && direction.magnitude < catchUpDistance)
        {
            Vector3 moveDirection = direction.normalized * followSpeed * Time.deltaTime;

            transform.position += moveDirection;

            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);

        }
        else if (direction.magnitude > catchUpDistance)
        {
            Vector3 moveDirection = direction.normalized * catchUpSpeed * Time.deltaTime;

            transform.position += moveDirection;

            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        }
    }

    private void AttackEnemy()
    {
        anim.SetBool("attack", true); // Trigger the attack animation
        // You can add other attack logic here, such as damage dealing or cooldown
    }

    private void UpdateAnimator()
    {
        // Calculate speed by comparing the current position with the last position
        float movementSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;

        // If the NPC is not moving, set speed to 0
        anim.SetFloat("speed", movementSpeed > 0.01f ? movementSpeed : 0f);

        // Update the last position for the next frame
        lastPosition = transform.position;
    }


}
