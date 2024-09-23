using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int healthRegain = 100;
    [SerializeField] public Transform checkPointPos;
    [SerializeField] public bool checkPointCaptured = false;
    [SerializeField] private ParticleSystem captureVFX;
    public AudioClip SFX;

    HealthManager healthManager;
    SoundManager soundManager;
    
    private void OnTriggerEnter(Collider other)
    {
        soundManager = FindObjectOfType<SoundManager>();
        

        if ( other.CompareTag("Player"))
        {
            if (!checkPointCaptured)
            {
                checkPointCaptured = true;
                GameManager.Instance.UpdateCheckpoint(checkPointPos);
                Instantiate(captureVFX, checkPointPos);

                healthManager = other.gameObject.GetComponent<HealthManager>();
                healthManager.AddHealth(healthRegain);
                soundManager.playSFX(SFX);
            }

            
        }
        
    }

    /*public void saveCheckpoint()
    {
        SaveSystem.SaveCheckpoint(this);
    }*/

}
