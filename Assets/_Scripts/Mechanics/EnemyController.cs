using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float stoppingDistance = 2f;
    private bool isAttacking = false;
    Animator anim;
    Rigidbody rb;
    HealthManager healthManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        healthManager = GetComponent<HealthManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            follow(other.transform);

            // Only start attacking if not already attacking
            if (!isAttacking)
            {
                StartCoroutine(shoot(attackSpeed));
            }

            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0;  // Ignore vertical rotation

            // Create a rotation that looks in the direction of the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;

            Debug.Log(other.name + " has entered attacking radius.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("attack", false);
        isAttacking = false; // Reset the attacking state when target leaves
        Debug.Log(other.name + " has left attacking radius.");
    }

    void attack()
    {
        anim.SetBool("attack", true);
    }

    IEnumerator shoot(int seconds)
    {
        isAttacking = true; // Set the attacking flag
        attack();
        yield return new WaitForSeconds(seconds);
        anim.SetBool("attack", false);
        isAttacking = false; // Reset the attacking flag after the attack is finished
    }

    public void follow(Transform target)
    {
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude > stoppingDistance)
        {
            Vector3 moveDirection = direction.normalized * followSpeed * Time.fixedDeltaTime; // Use fixedDeltaTime

            // Move using Rigidbody
            rb.MovePosition(transform.position + moveDirection);

            // Smooth rotation
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        }
    }

}
