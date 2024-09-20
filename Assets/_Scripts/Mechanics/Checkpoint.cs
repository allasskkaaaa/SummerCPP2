using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Checkpoint : MonoBehaviour
{
    public enum levelNumber
    {
        one, two, three, four, five, six, seven
    }

    [SerializeField] private Transform checkPointPos;
    [SerializeField] private bool checkPointCaptured = false;
    [SerializeField] private ParticleSystem captureVFX;
    [SerializeField] private levelNumber levelTransition;
    private int level;
    // Start is called before the first frame update

    private void Start()
    {
        if (levelTransition == levelNumber.one)
        {
            level = 1;
        } else if (levelTransition == levelNumber.two)
        {
            level = 2;
        } else if (levelTransition == levelNumber.three)
        {
            level = 3;
        } else if (levelTransition == levelNumber.four)
        {
            level = 4;
        } else if (levelTransition == levelNumber.five)
        {
            level = 5;
        } else if (levelTransition == levelNumber.six)
        {
            level = 6;
        } else if (levelTransition == levelNumber.seven)
        {
            level = 7;
        }
    }
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
