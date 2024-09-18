using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float stoppingDistance = 2f;

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
