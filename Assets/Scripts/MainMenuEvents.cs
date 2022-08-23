using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenuEvents class that defines events in MainMenu
/// </summary>
public class MainMenuEvents : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnStart event starts the game
    /// </summary>
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// OnExit event exits the game
    /// </summary>
    public void OnExit()
    {
        Application.Quit();
    }
}
