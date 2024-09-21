using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int score = 40;
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Score increased");
        GameManager.Instance.score += score;
        Destroy(gameObject);
        
    }

    private void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Score increased");
            GameManager.Instance.score += score;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Score decreased");
            GameManager.Instance.score -= score;
            Destroy(gameObject);
        }
    }
}
