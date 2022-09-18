using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool isGameOver = false;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePanel;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UI Manager on GameManager is <null>");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver == true)
        {
            SceneManager.LoadScene("Game");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }



    public void GameOver()
    {
        Debug.Log("GameManager::GameOver() called");
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        isGameOver = true;
        _uiManager.GameOverSequence();   
    }
    

    public void PauseGame()
    {
        Debug.Log("Game is paused");
        _uiManager.HideInPause(); // Buna gerek olamayabilir       
        pauseMenuPanel.SetActive(true);
        isGamePaused = true;
        //Time.timeScale = 0f; // Buna gerek olmayabilir, çünkü devam eden bir şey yok
    }

    public void ResumeGame()
    {
        Debug.Log("Game is resumed");
        if(pauseMenuPanel.activeSelf)
        {
            
            pauseMenuPanel.SetActive(false);
            _uiManager.ShowOutPause();  // Buna gerek olmayabilir
            isGamePaused = false;
            //Time.timeScale = 1.0f;  // Buna gerek olmayabilir, PauseGame() kısmında silersek burada da sil           
        }
    }

    public void GoMainMenu()
    {
        Debug.Log("Going main manu");
        //Time.timeScale = 1.0f; // Öncekilerde olduğu gibi, diğerlerini silersen bunu da sil
        SceneManager.LoadScene("Main_Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Leaving game to windows");
        Application.Quit();
    }
}
