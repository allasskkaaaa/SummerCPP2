using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcType;

    public AudioClip SFX;

    SoundManager soundManager;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 10, transform.position.z);
        Instantiate(npcType, spawnPosition, transform.rotation);
        
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.playSFX(SFX);
        GameManager.Instance.NPCList.Add(npcType);
        Destroy(collision.gameObject);
        Destroy(gameObject);
        
    }
}
