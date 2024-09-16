using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    public int level = 0; //Indicates the level
    public int setLevel; //Indicates the level the player passing through the gate moves onto
    public List<Transform> enemySpawns; //the spawn points for the enemies
    public List<GameObject> enemies; //The enemies that will spawn from enemySpawn transform

    public void OnCollisionEnter(Collision collision)
    {
        onLevelChange();
    }


    public void onLevelChange()
    {
        spawnEnemies();
    }

    private void spawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Instantiate(enemies[i]); //Instantiates a random enemy from the enemy list
        }
    }
}
