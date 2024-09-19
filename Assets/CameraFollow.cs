using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Target = GameManager.Instance.PlayerInstance.transform;
        }

        if (Target != null)
        {
            Vector3 targetPosition = Target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
