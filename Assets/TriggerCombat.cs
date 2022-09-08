using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that triggers the combat against the boss
/// </summary>
public class TriggerCombat : MonoBehaviour
{
    /// <summary>
    /// Script to enable when the player gets to close
    /// </summary>
    public BossesMovement bossMovement;

    /// <summary>
    /// door gameobject to active when the player pass to the boss room
    /// </summary>
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bossMovement.enabled = true;
            door.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
