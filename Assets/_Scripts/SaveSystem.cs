using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerController player, HealthManager healthManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player, healthManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveCheckpoint(Checkpoint checkpoint)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/checkpoint.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        CheckpointData data = new CheckpointData(checkpoint);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CheckpointData LoadCheckpoint()
    {
        string path = Application.persistentDataPath + "/checkpoint.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CheckpointData data = formatter.Deserialize(stream) as CheckpointData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Checkpoint save file not found in " + path);
            return null;
        }
    }

    public static void SaveGameManager(GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameManager.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameManagerData data = new GameManagerData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameManagerData LoadGameManager()
    {
        string path = Application.persistentDataPath + "/gameManager.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameManagerData data = formatter.Deserialize(stream) as GameManagerData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("GameManager save file not found in " + path);
            return null;
        }
    }

    public static void SaveInventory(InventoryManager inventoryManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        InventoryData data = new InventoryData(inventoryManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InventoryData LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData data = formatter.Deserialize(stream) as InventoryData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Inventory save file not found in " + path);
            return null;
        }
    }

    public static void SaveNPC(NPCController npc, HealthManager healthManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/npc.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        NPCData data = new NPCData(npc, healthManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static NPCData LoadNPC()
    {
        string path = Application.persistentDataPath + "/npc.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            NPCData data = formatter.Deserialize(stream) as NPCData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("NPC save file not found in " + path);
            return null;
        }
    }

    public static void SaveEnemy(EnemyController enemy, HealthManager healthManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/enemy.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        EnemyData data = new EnemyData(enemy, healthManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EnemyData LoadEnemy()
    {
        string path = Application.persistentDataPath + "/enemy.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Enemy save file not found in " + path);
            return null;
        }
    }

    public static void SaveScoreObject(GameObject scoreObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scoreObject.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);
        ScoreObjData data = new ScoreObjData(scoreObject);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreObjData LoadScoreObject()
    {
        string path = Application.persistentDataPath + "/scoreObject.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreObjData data = formatter.Deserialize(stream) as ScoreObjData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("ScoreObject save file not found in " + path);
            return null;
        }
    }

    public static void SaveLevel(LevelData levelData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.gbr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, levelData);
        stream.Close();
    }

    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.gbr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData levelData = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return levelData;

        }
        else
        {
            Debug.LogError("Level save file not found in " + path);
            return null;
        }
    }

}
