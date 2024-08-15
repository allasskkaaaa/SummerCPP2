using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameManager.Instance.health -= damage;
    }
}
