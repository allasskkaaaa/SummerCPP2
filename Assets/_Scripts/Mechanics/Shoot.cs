using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootSpawn;
    public GameObject projectile;

    PlayerController pc;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (pc.canShoot)
            anim.SetTrigger("shoot");          
        }
        
    }

    public void SpawnProjectile()
    {
        if (projectile && shootSpawn)
        {
            Instantiate(projectile, shootSpawn.position, shootSpawn.rotation);
        }
    }
}
