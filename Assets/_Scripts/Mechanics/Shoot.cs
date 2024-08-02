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
        if (Input.GetKeyUp(KeyCode.LeftControl) && gameObject.CompareTag("Player"))
        {
            Debug.Log("Shoot");
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(projectile, ShootSpawn.position, ShootSpawn.rotation);
    }
}
