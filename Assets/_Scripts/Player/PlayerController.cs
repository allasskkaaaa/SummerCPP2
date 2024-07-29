using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    CharacterController cc;

    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        gravity = Physics.gravity.y;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(hInput, 0, vInput);
        moveDirection *= speed;
        moveDirection.y = gravity;
        moveDirection *= Time.deltaTime;

        cc.Move(moveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    
}
