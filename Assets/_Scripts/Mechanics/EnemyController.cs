using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy Variables
    //[SerializeField] private float detectionRadius = 10;
    [SerializeField] private int attackSpeed = 3;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if  (other.CompareTag("Player") || other.CompareTag("NPC"))
            anim.SetBool("attack",true);

        Vector3 direction = other.transform.position - transform.position;
        direction.y = 0;  // Ignore vertical rotation

        // Create a rotation that looks in the direction of the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Apply the rotation
        transform.rotation = targetRotation;
        //transform.LookAt(other.transform.position);

        Debug.Log(other.name + "has entered attacking radius.");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("attack", false);
        Debug.Log(other.name + "has left attacking radius.");
    }

    void attack()
    {
        anim.SetBool("attack", true);
    }
}