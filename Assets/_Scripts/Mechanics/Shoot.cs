using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootSpawn;
    public GameObject projectile;
    public GameObject shooter;
    public AudioClip SFX;

    PlayerController pc;
    Animator anim;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();

        if (shooter == null)
        {
            Debug.Log("Shooter has not been specified");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (pc.canShoot) 
                    anim.SetTrigger("shoot");
                if (pc.canMelee)
                    anim.SetTrigger("shoot");
            }

    }

    public void SpawnProjectile()
    {
        if (projectile && shootSpawn)
        {
            GameObject projectileInstance = Instantiate(projectile, shootSpawn.position, shootSpawn.rotation);
            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            projectileScript.shooter = this.gameObject; // Assign the shooter
            soundManager.playSFX(SFX);
        }
    }
}
