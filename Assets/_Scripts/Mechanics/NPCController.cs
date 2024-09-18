using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10;
    [SerializeField] private int attackSpeed = 3;
    [SerializeField] private int speed = 7;
    private bool isOccupied = false;


    //Reference Variables
    [SerializeField] private Transform player;
    Follow follow;
    Animator anim;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        anim = GetComponent<Animator>();
        follow = GetComponent<Follow>();
    }

    private void Update()
    {

        if (!isOccupied)
        follow.follow(player);
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

}
