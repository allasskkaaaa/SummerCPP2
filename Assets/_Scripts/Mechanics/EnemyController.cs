using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float stoppingDistance = 2f;
    [SerializeField] public Collider radius;

    public AudioClip AxeSFX;
    private bool isAttacking = false;
    Animator anim;
    Rigidbody rb;
    HealthManager healthManager;
    SoundManager soundManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        healthManager = GetComponent<HealthManager>();
        soundManager = FindObjectOfType<SoundManager>();
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
        /*anim.SetBool("attack", false);
        isAttacking = false; // Reset the attacking state when target leaves
        Debug.Log(other.name + " has left attacking radius.");*/
    }

    public void axeSFX()
    {
        soundManager.playSFX(AxeSFX);
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

        // Check if the target is farther than the stopping distance
        if (direction.magnitude > stoppingDistance)
        {
            // Normalize direction and apply follow speed (without Time.fixedDeltaTime)
            Vector3 moveDirection = direction.normalized * followSpeed;

            // Move using Rigidbody
            rb.MovePosition(transform.position + moveDirection * Time.deltaTime); // Use Time.deltaTime for smooth movement

            // Smooth rotation
            direction.y = 0; // Keep the enemy from rotating on the Y-axis
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        }
    }


}
