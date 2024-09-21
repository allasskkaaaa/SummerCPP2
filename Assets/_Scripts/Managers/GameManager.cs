using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject NPCPrefab; // A separate list for NPC prefabs
    public List<GameObject> NPCList; // List to track instantiated NPCs
    static GameManager _instance;
    public Action<int> OnScoreValueChange;
    public bool loadGameData;
    public static GameManager Instance => _instance;

    private int _score;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreValueChange?.Invoke(_score);
        }
    }

    [SerializeField] private PlayerController playerPrefab;

    [HideInInspector] public PlayerController PlayerInstance => _playerinstance;
    PlayerController _playerinstance = null;
    public Transform currentCheckpoint;
    public InventoryManager inventorymanager;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
            return;
        }

        Destroy(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (loadGameData)
        {
            LoadGameData();
            loadGameData = false; // Reset the flag
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadGameDataOnStart()
    {
        loadGameData = true;
    }

    public void GameOver()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    public void Respawn()
    {
        if (_playerinstance != null && currentCheckpoint != null)
        {
            _playerinstance.transform.position = currentCheckpoint.position;
            Debug.Log("Respawn");
        }
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        _playerinstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    public void UpdateCheckpoint(Transform updatedCheckpoint)
    {
        currentCheckpoint = updatedCheckpoint;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        score = 0;
    }

    public void Victory()
    {
        SceneManager.LoadScene(3);
    }

    public void SaveNPCs()
    {
        SaveSystem.SaveNPCList(NPCList);
    }

    public void LoadNPCs()
    {
        string path = Application.persistentDataPath + "/npcList.gbr";

        // Check if the NPC save file exists
        if (System.IO.File.Exists(path))
        {
            NPCDataList data = SaveSystem.LoadNPCList(); // Load NPC data
            if (data != null && data.npcDataList.Count > 0)
            {
                // Clear existing NPCs
                foreach (GameObject npc in NPCList)
                {
                    Destroy(npc);
                }
                NPCList.Clear();

                // Loop through the saved NPC data and respawn NPCs
                foreach (NPCData npcData in data.npcDataList)
                {
                    GameObject npc = Instantiate(NPCPrefab); // Instantiate NPC prefab

                    // Set the NPC's position
                    npc.transform.position = new Vector3(npcData.NPCPos[0], npcData.NPCPos[1], npcData.NPCPos[2]);

                    // Assign the saved health
                    HealthManager healthManager = npc.GetComponent<HealthManager>();
                    if (healthManager != null)
                    {
                        healthManager.health = npcData.health;
                    }

                    NPCList.Add(npc); // Add to the NPC list
                }
            }
            else
            {
                Debug.Log("No NPC data found or the NPC list is empty.");
            }
        }
        else
        {
            Debug.LogError("NPC save file not found!");
        }
    }


    public void LoadGameData()
    {
        LoadGameManager(); // Load game manager data
        LoadNPCs(); // Load NPCs
        SpawnPlayer(currentCheckpoint); // Respawn player
        inventorymanager.LoadInventory();
    }

    public void SaveGameManager()
    {
        SaveSystem.SaveGameManager(this); // Save game manager data
    }

    public void LoadGameManager()
    {
        GameManagerData data = SaveSystem.LoadGameManager();

        score = data.score; // Load score

        // Ensure currentCheckpoint is assigned
        if (currentCheckpoint == null)
        {
            Debug.LogWarning("Current checkpoint is null, creating a default one.");
            currentCheckpoint = new GameObject("DefaultCheckpoint").transform;
            currentCheckpoint.position = Vector3.zero; // Set to some default position
        }

        // Set the position of the current checkpoint using loaded data
        if (data.currentCheckpointPos != null && data.currentCheckpointPos.Length >= 3)
        {
            currentCheckpoint.position = new Vector3(data.currentCheckpointPos[0], data.currentCheckpointPos[1], data.currentCheckpointPos[2]);
        }
        else
        {
            Debug.LogWarning("No valid checkpoint position found in saved data.");
        }
    }

}
