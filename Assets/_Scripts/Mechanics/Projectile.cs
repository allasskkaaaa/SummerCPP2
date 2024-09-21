using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int moveSpeed = 7;
    public float lifetime = 5.0f;
    public int bulletDamage = 20;
    Rigidbody rb;

    private HealthManager healthManager;
    public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;

        lifetime -= Time.deltaTime; // Increment timer by the time since last frame

        if (lifetime <= 0)
        {
            Destroy(gameObject); // Destroy the object if lifetime is exceeded
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == shooter)
        {
            return;
        }

        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            healthManager = other.gameObject.GetComponent<HealthManager>();
            healthManager.TakeDamage(bulletDamage);
        }
       

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }



}
