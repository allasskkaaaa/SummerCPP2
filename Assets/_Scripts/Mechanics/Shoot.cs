using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ShootSpawn;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            Instantiate(projectile, ShootSpawn.position, ShootSpawn.rotation);
        }
    }
}
