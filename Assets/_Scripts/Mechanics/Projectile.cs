using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int moveSpeed = 7;
    public float lifetime = 5.0f;
    public int scoreAmount;
    Rigidbody rb;
    
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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
            case "Player":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Health":
                Debug.Log("Health increased");
                GameManager.Instance.health += 10;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Score":
                Debug.Log("Score increased");
                GameManager.Instance.score += 40;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Level":
                Destroy(gameObject);
                break;

            default:
                Destroy(collision.gameObject);
                break;
        }
    }
}
