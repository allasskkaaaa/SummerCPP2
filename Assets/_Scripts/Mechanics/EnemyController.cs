using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float stoppingDistance = 2f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
            StartCoroutine(shoot(attackSpeed));

        follow(other.transform);
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

    IEnumerator shoot(int seconds)
    {
        attack();
        yield return new WaitForSeconds(seconds);
        anim.SetBool("attack", false);
    }

    public void follow(Transform target)
    {
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude > stoppingDistance)
        {
            Vector3 moveDirection = direction.normalized * followSpeed * Time.deltaTime;

            transform.position += moveDirection;

            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * followSpeed);
        }
    }
}