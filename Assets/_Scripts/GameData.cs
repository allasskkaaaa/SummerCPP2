using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData 
{
    //Player Controller
    public float speed;
    public float rotationSpeed;
    public bool canShoot;
    public bool canMelee;

    //Health Manager
    public int health;
    public int lives;

    //Inventory Manager
    public bool isPrimaryFilled;
    public bool isSecondaryFilled;

    public string primaryObjectTag; // Name of the object in the primary slot
    public string secondaryObjectTag; // Name of the object in the secondary slot
    public PlayerData (PlayerController player, HealthManager healthManager, InventoryManager inventoryManager)
    {
        canShoot = player.canShoot;
        canMelee = player.canMelee;

        health = healthManager.health;
        lives = healthManager.lives;

        isPrimaryFilled = inventoryManager.isPrimaryFilled;
        isSecondaryFilled = inventoryManager.isSecondaryFilled;

        if (inventoryManager.primaryObject != null)
        {
            primaryObjectTag = inventoryManager.primaryObject.tag;
        }

        if (inventoryManager.secondaryObject != null)
        {
            secondaryObjectTag = inventoryManager.secondaryObject.tag;
        }
        Debug.Log($"Primary Filled: {isPrimaryFilled}, Secondary Filled: {isSecondaryFilled}");
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

/*[System.Serializable]
public class InventoryData
{
    public bool isPrimaryFilled;
    public bool isSecondaryFilled;

    public string primaryObjectTag; // Name of the object in the primary slot
    public string secondaryObjectTag; // Name of the object in the secondary slot

    public InventoryData(InventoryManager inventoryManager)
    {
        isPrimaryFilled = inventoryManager.isPrimaryFilled;
        isSecondaryFilled = inventoryManager.isSecondaryFilled;

        if (inventoryManager.isPrimaryFilled)
        {
            primaryObjectTag = inventoryManager.primaryObject.tag;
        }
        
        if (inventoryManager.isSecondaryFilled)
        {
            secondaryObjectTag = inventoryManager.secondaryObject.tag;
        }
        
    }
}*/

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

