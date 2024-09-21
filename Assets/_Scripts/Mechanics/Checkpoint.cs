using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int healthRegain = 100;
    [SerializeField] public Transform checkPointPos;
    [SerializeField] public bool checkPointCaptured = false;
    [SerializeField] private ParticleSystem captureVFX;
    [SerializeField] SpawnManager spawnManager;
    private int level;

    HealthManager healthManager;
    
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            if (!checkPointCaptured)
            {
                checkPointCaptured = true;
                GameManager.Instance.UpdateCheckpoint(checkPointPos);
                Instantiate(captureVFX, checkPointPos);
                GameManager.Instance.level = level;
            }

            healthManager = other.gameObject.GetComponent<HealthManager>();
            healthManager.AddHealth(healthRegain);
        }
        
    }

}
