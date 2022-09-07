using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// WeakPointsHandler class that defines the damage from the player
/// </summary>
public class WeakPointsHandler : MonoBehaviour
{
    /// <summary>
    /// array of hearths
    /// </summary>
    public GameObject[] hearths;


    private int count = 0;

    /// <summary>
    /// boss gameobject
    /// </summary>
    public GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            Vector3 vel = other.gameObject.GetComponent<Rigidbody>().velocity;
            if (vel.magnitude > 3)
            {
                foreach(var h in hearths)
                {
                    if (h.activeInHierarchy == true)
                    {
                        h.SetActive(false);
                        if (count == 2)
                            count++;
                        break;
                    }
                    else
                        count++;
                }
                if (count == 3)
                    boss.SetActive(false);
            }


        }
    }
}
