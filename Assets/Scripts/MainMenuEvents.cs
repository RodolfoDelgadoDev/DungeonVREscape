using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenuEvents class that defines events in MainMenu
/// </summary>
public class MainMenuEvents : MonoBehaviour
{
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

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
