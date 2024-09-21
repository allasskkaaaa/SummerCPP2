using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    static GameManager _instance;
    //public Action<int> OnLifeValueChange;
    public Action<int> OnScoreValueChange;
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
    Transform currentCheckpoint;

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

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
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
}

