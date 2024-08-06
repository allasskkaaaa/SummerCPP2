using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerInstance = GameManager.Instance.PlayerInstance;
        Target = playerInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            Vector3 targetPosition = Target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
