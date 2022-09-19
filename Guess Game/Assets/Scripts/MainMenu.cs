using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Game is Loading...");
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Leaving game to windows");
        Application.Quit();
    }
}
