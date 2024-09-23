using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedboost : MonoBehaviour
{
    [SerializeField] private float speedChange = 10f;
    [SerializeField] private float changeLength = 5f;
    private bool activated = false;
    PlayerController pc;

    public AudioClip SFX;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!activated)
            {
                Debug.Log("Speedboost activated");
                pc = other.GetComponent<PlayerController>();

                StartCoroutine(pc.Speedboost(speedChange, changeLength));
                soundManager.playSFX(SFX);
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (activated)
        activated = false;
    }

}
