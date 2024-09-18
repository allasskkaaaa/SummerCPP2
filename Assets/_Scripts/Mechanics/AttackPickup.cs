using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    public GameObject NPC;

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

            case "NPC":
                Debug.Log("NPC killed.");
                GameManager.Instance.score -= 40;
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
