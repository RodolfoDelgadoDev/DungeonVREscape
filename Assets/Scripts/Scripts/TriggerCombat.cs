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
    
    /// <summary>
    /// combatMusic to set on when the player gets close to the boss
    /// </summary>
    public GameObject combatMusic;

    /// <summary>
    /// spawnMusic to turn of when the battle starts
    /// </summary>
    public GameObject spawnMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            bossMovement.enabled = true;
            door.SetActive(true);
            spawnMusic.SetActive(false);
            combatMusic.SetActive(true);
            combatMusic.GetComponent<AudioSource>().Play();
            this.gameObject.SetActive(false);
        }
    }

}
