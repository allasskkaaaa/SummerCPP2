using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10;
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private int speed = 7;
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float stoppingDistance = 2f;
    [SerializeField] private float catchUpSpeed = 8f; //Speed when NPC lags behind and needs to catchup to the player
    [SerializeField] private float catchUpDistance = 12f; //Distance the NPC starts to catchup
    private bool isOccupied = false;
    private Vector3 lastPosition;


    //Reference Variables
    [SerializeField] private Transform player;
    Animator anim;

    private void Start()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerInstance.transform;
        }

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerInstance.transform;
        }

        if (!isOccupied)
        {
            follow(player);
            UpdateAnimator();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isOccupied = true;

            anim.SetBool("attack",true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Stops attacking
        anim.SetBool("attack", false);
        isOccupied = false;
    }

    public void follow(Transform target)
    {
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude > stoppingDistance && direction.magnitude < catchUpDistance) //Check if NPC is within normal following distance
        {
            Vector3 moveDirection = direction.normalized * followSpeed * Time.deltaTime;

            transform.position += moveDirection;

            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        } else if (direction.magnitude > catchUpDistance) //If NPC is too far from player
        {
            Vector3 moveDirection = direction.normalized * catchUpSpeed * Time.deltaTime;

            transform.position += moveDirection;

            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        }
    }

    private void UpdateAnimator()
    {
        // Calculate speed by comparing the current position with the last position
        float movementSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;

        // If the NPC is not moving, set speed to 0
        if (movementSpeed > 0.01f)
        {
            anim.SetFloat("speed", movementSpeed);
        }
        else
        {
            anim.SetFloat("speed", 0f);
        }

        // Update the last position for the next frame
        lastPosition = transform.position;
    }

}
