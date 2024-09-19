using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private Transform startPos;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerInstance == null)
        {
            GameManager.Instance.SpawnPlayer(startPos);
        }
    }


}
