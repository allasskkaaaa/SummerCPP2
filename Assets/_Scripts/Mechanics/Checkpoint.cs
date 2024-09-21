using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int healthRegain = 100;
    [SerializeField] public Transform checkPointPos;
    [SerializeField] public bool checkPointCaptured = false;
    [SerializeField] private ParticleSystem captureVFX;

    HealthManager healthManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            if (!checkPointCaptured)
            {
                checkPointCaptured = true;
                GameManager.Instance.UpdateCheckpoint(checkPointPos);
                Instantiate(captureVFX, checkPointPos);
            }

            healthManager = other.gameObject.GetComponent<HealthManager>();
            healthManager.AddHealth(healthRegain);
        }
        
    }

    /*public void saveCheckpoint()
    {
        SaveSystem.SaveCheckpoint(this);
    }*/

}
