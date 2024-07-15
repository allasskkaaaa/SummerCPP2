using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endButton;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            endButton.SetActive(true);

        Debug.Log("Trigger Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            endButton.SetActive(false);

        Debug.Log("Trigger Exit");
    }
}
