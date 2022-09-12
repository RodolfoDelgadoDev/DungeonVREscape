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
    /// Array that had all the characters of LIFE
    /// </summary>
    [SerializeField] GameObject[] Life;


    /// <summary>
    /// Give Inmortality to the player after gets an attack
    /// </summary>
    private bool onInmortality = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && onInmortality == false)
        {      
            if (Life[3].activeInHierarchy == true)
                Life[3].SetActive(false);
            else if (Life[2].activeInHierarchy == true)
                Life[2].SetActive(false);
            else if (Life[1].activeInHierarchy == true)
                Life[1].SetActive(false);
            else if (Life[0].activeInHierarchy == true)
            {
                Life[0].SetActive(false);
                SceneManager.LoadScene(0);
            }
            onInmortality = true;
            StartCoroutine(Inmortality());
        }
    }

    IEnumerator Inmortality()
    {
        yield return new WaitForSeconds(3f);
        onInmortality = false;
    }


}
