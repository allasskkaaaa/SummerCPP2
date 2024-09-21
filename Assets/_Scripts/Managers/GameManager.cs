using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> NPCList;
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

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
        
    }

    private void Start()
    {

        //health = maxHealth;
    }
    /*void onSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (loadGameData)
        {
            LoadGameData();
        }
    }*/
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void DontLoadGameData()
    {
        loadGameData = true;
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
        _playerinstance.transform.position = currentCheckpoint.position;
        Debug.Log("Respawn");
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        _playerinstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
        currentCheckpoint = spawnLocation;
    }

    public void UpdateCheckpoint(Transform updatedCheckpoint)
    {
        currentCheckpoint = updatedCheckpoint;
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
        restartGame();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
        score = 0;

    }
    public void victory()
    {
        SceneManager.LoadScene(3);
    }

    public void SaveNPCs()
    {
        SaveSystem.SaveNPCList(NPCList);
    }

    public void LoadNPCs()
    {
        NPCDataList data = SaveSystem.LoadNPCList();
        if (data != null)
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
                // Instantiate an NPC prefab (assumes you have an NPC prefab assigned)

                foreach (GameObject npcPrefab in NPCList)
                {
                    GameObject npc = Instantiate(npcPrefab);

                    // Set the NPC's position
                    npc.transform.position = new Vector3(npcData.NPCPos[0], npcData.NPCPos[1], npcData.NPCPos[2]);

                    // Assign the saved health
                    HealthManager healthManager = npc.GetComponent<HealthManager>();
                    healthManager.health = npcData.health;

                    NPCList.Add(npc);
                }
                
            }
        }
    }
    public void LoadGameData()
    {
        LoadGameManager();
        LoadNPCs();
        Respawn();
        GameManager.Instance.PlayerInstance.LoadPlayer();
    }


    public void SaveGameManager()
    {
        SaveSystem.SaveGameManager(this);
    }

    public void LoadGameManager()
    {
        GameManagerData data = SaveSystem.LoadGameManager();

        score = data.score;

        if (currentCheckpoint != null)
        {
            currentCheckpoint.position = new Vector3(data.currentCheckpointPos[0], data.currentCheckpointPos[1], data.currentCheckpointPos[2]);
        }
        else
        {
            Debug.LogError("Checkpoint Transform is not assigned!");
        }

    }
}

