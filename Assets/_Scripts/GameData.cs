using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public float speed;
    public float rotationSpeed;
    public bool canShoot;
    public bool canMelee;
    public int health;
    public int lives;

    public PlayerData (PlayerController player, HealthManager healthManager)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        canShoot = player.canShoot;
        canMelee = player.canMelee;

        health = healthManager.health;
        lives = healthManager.lives; 

    }
}

[System.Serializable]
public class CheckpointData
{

    public bool checkPointCaptured;

    public CheckpointData(Checkpoint checkPoint)
    {
        checkPointCaptured = checkPoint.checkPointCaptured;
    }
}
[System.Serializable]
public class GameManagerData
{
    public int score;

    public GameManagerData(GameManager gm)
    {
        score = gm.score;
    }
     
}

[System.Serializable]
public class InventoryData
{
    public bool isPrimaryFilled;
    public bool isSecondaryFilled;
    public float[] primaryObjectPos;
    public float[] primaryObjectRot;
    public float[] secondaryObjectPos;
    public float[] secondaryObjectRot;

    public InventoryData(InventoryManager inventoryManager)
    {
        isPrimaryFilled = inventoryManager.isPrimaryFilled;
        isSecondaryFilled = inventoryManager.isSecondaryFilled;

        primaryObjectPos = new float[3];
        primaryObjectPos[0] = inventoryManager.primaryObject.transform.position.x;
        primaryObjectPos[1] = inventoryManager.primaryObject.transform.position.y;
        primaryObjectPos[2] = inventoryManager.primaryObject.transform.position.z;

        primaryObjectRot = new float[3];
        primaryObjectRot[0] = inventoryManager.primaryObject.transform.rotation.x;
        primaryObjectRot[1] = inventoryManager.primaryObject.transform.rotation.y;
        primaryObjectRot[2] = inventoryManager.primaryObject.transform.rotation.z;

        secondaryObjectPos = new float[3];
        secondaryObjectPos[0] = inventoryManager.secondaryObject.transform.position.x;
        secondaryObjectPos[1] = inventoryManager.secondaryObject.transform.position.y;
        secondaryObjectPos[2] = inventoryManager.secondaryObject.transform.position.z;

        secondaryObjectRot = new float[3];
        secondaryObjectRot[0] = inventoryManager.secondaryObject.transform.rotation.x;
        secondaryObjectRot[1] = inventoryManager.secondaryObject.transform.rotation.y;
        secondaryObjectRot[2] = inventoryManager.secondaryObject.transform.rotation.z;
    }

}

[System.Serializable]
public class NPCData
{
    public int health;
    public float[] NPCPos;

    public NPCData(NPCController npc, HealthManager healthManager)
    {
        health = healthManager.health;

        NPCPos = new float[3];
        NPCPos[0] = npc.transform.position.x;
        NPCPos[1] = npc.transform.position.y;
        NPCPos[2] = npc.transform.position.z;
    }
}

[System.Serializable]
public class EnemyData
{
    public int health;
    public float[] enemyPos;

    public EnemyData(EnemyController enemy, HealthManager healthManager)
    {
        health = healthManager.health;

        enemyPos = new float[3];
        enemyPos[0] = enemy.transform.position.x;
        enemyPos[1] = enemy.transform.position.y;
        enemyPos[2] = enemy.transform.position.z;
    }
}

[System.Serializable]
public class ScoreObjData
{
    public float[] ScorePos;

    public ScoreObjData(GameObject score)
    {
        if (score != null)
        {
            ScorePos = new float[3];
            ScorePos[0] = score.transform.position.x;
            ScorePos[1] = score.transform.position.y;
            ScorePos[2] = score.transform.position.z;
        }
        
    }
}

[System.Serializable]
public class LevelData
{
    public List<ScoreObjData> scoreObjList = new List<ScoreObjData>();
}


