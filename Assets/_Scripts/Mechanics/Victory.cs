using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
