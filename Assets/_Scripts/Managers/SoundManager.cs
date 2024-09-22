using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;

    /*public AudioClip Damage;
    public AudioClip AxeSwing;
    public AudioClip GunShot;
    public AudioClip CheckpointGet;
    public AudioClip NPC_Spawn;
    public AudioClip Score_Get;
    public AudioClip Speedboost;*/

    public void playSFX(AudioClip audioClip )
    {
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }
}
