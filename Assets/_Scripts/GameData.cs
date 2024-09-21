using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData 
{
    //public float[] position;
    public float speed;
    public float rotationSpeed;
    public bool canShoot;
    public bool canMelee;
    public int health;
    public int lives;

    public PlayerData (PlayerController player, HealthManager healthManager)
    {
        /*position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;*/

        canShoot = player.canShoot;
        canMelee = player.canMelee;

        health = healthManager.health;
        lives = healthManager.lives; 

    }
}

/*[System.Serializable]
public class CheckpointData
{

    public bool checkPointCaptured;
    public float[] checkPointPos;

    public CheckpointData(Checkpoint checkPoint)
    {
        checkPointCaptured = checkPoint.checkPointCaptured;

        checkPointPos = new float[3];
        checkPointPos[0] = checkPoint.transform.position.x;
        checkPointPos[1] = checkPoint.transform.position.y;
        checkPointPos[2] = checkPoint.transform.position.z;
    }
}*/

[System.Serializable]
public class GameManagerData
{
    public int score;
    public float[] currentCheckpointPos;

    public GameManagerData(GameManager gm)
    {
        score = gm.score;

        if (gm.currentCheckpoint != null)
        {
            currentCheckpointPos = new float[3];
            currentCheckpointPos[0] = gm.currentCheckpoint.position.x;
            currentCheckpointPos[1] = gm.currentCheckpoint.position.y;
            currentCheckpointPos[2] = gm.currentCheckpoint.position.z;
        }
        
    }
     
}

[System.Serializable]
public class InventoryData
{
    public bool isPrimaryFilled;
    public bool isSecondaryFilled;

    public string primaryObjectName; // Name of the object in the primary slot
    public string secondaryObjectName; // Name of the object in the secondary slot

    public float[] primaryObjectPos;
    public float[] primaryObjectRot;

    public float[] secondaryObjectPos;
    public float[] secondaryObjectRot;

    public InventoryData(InventoryManager inventoryManager)
    {
        isPrimaryFilled = inventoryManager.isPrimaryFilled;
        isSecondaryFilled = inventoryManager.isSecondaryFilled;

        if (inventoryManager.primaryObject != null)
        {
            primaryObjectName = inventoryManager.primaryObject.name.Replace("(Clone)", "").Trim(); // Store the object's name, removing the "(Clone)" suffix Unity adds
            primaryObjectPos = new float[3];
            primaryObjectPos[0] = inventoryManager.primaryObject.transform.position.x;
            primaryObjectPos[1] = inventoryManager.primaryObject.transform.position.y;
            primaryObjectPos[2] = inventoryManager.primaryObject.transform.position.z;

            primaryObjectRot = new float[4];
            primaryObjectRot[0] = inventoryManager.primaryObject.transform.rotation.x;
            primaryObjectRot[1] = inventoryManager.primaryObject.transform.rotation.y;
            primaryObjectRot[2] = inventoryManager.primaryObject.transform.rotation.z;
            primaryObjectRot[3] = inventoryManager.primaryObject.transform.rotation.w;
        }

        if (inventoryManager.secondaryObject != null)
        {
            secondaryObjectName = inventoryManager.secondaryObject.name.Replace("(Clone)", "").Trim(); // Store the object's name, removing the "(Clone)" suffix
            secondaryObjectPos = new float[3];
            secondaryObjectPos[0] = inventoryManager.secondaryObject.transform.position.x;
            secondaryObjectPos[1] = inventoryManager.secondaryObject.transform.position.y;
            secondaryObjectPos[2] = inventoryManager.secondaryObject.transform.position.z;

            secondaryObjectRot = new float[4];
            secondaryObjectRot[0] = inventoryManager.secondaryObject.transform.rotation.x;
            secondaryObjectRot[1] = inventoryManager.secondaryObject.transform.rotation.y;
            secondaryObjectRot[2] = inventoryManager.secondaryObject.transform.rotation.z;
            secondaryObjectRot[3] = inventoryManager.secondaryObject.transform.rotation.w;
        }
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
public class NPCDataList
{
    public List<NPCData> npcDataList = new List<NPCData>();
}

