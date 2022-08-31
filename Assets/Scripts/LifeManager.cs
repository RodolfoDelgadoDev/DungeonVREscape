using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// LifeManager class that defines the health to the player
/// </summary>
public class LifeManager : MonoBehaviour
{
    /// <summary>
    /// L character
    /// </summary>
    [SerializeField] GameObject L_chr;

    /// <summary>
    /// I character
    /// </summary>
    [SerializeField] GameObject I_chr;

    /// <summary>
    /// F character
    /// </summary>
    [SerializeField] GameObject F_chr;

    /// <summary>
    /// E character
    /// </summary>
    [SerializeField] GameObject E_chr;

    ///PlayerCollider to detect the damage to the player
    ///[SerializeField] Collider playerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (E_chr.activeInHierarchy == true)
                E_chr.SetActive(false);
            else if (F_chr.activeInHierarchy == true)
                F_chr.SetActive(false);
            else if (I_chr.activeInHierarchy == true)
                I_chr.SetActive(false);
            else if (F_chr.activeInHierarchy == true)
                F_chr.SetActive(false);
            else
                SceneManager.LoadScene(0);
        }
    }
}
