using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public AudioClip SFX;
    public int score = 40;

    SoundManager soundManager;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.playSFX(SFX);
            Debug.Log("Score increased");
            GameManager.Instance.score += score;
            Destroy(gameObject);
        }
        
        
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
