using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform checkPointPos;
    [SerializeField] private bool checkPointCaptured = false;
    [SerializeField] private ParticleSystem captureVFX;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointCaptured)
        {
            checkPointCaptured = true;
            GameManager.Instance.UpdateCheckpoint(checkPointPos);
            Instantiate(captureVFX, checkPointPos);
        } else
        {
            return;
        }
    }

}
