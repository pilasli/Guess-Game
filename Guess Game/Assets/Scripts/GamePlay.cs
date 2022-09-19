using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private int guess;
    private int downLimit = 0;
    private int topLimit = 1001;
    private float guessRight = 10;
    private int guessNumber = 0;

    private SavePrefs _savePrefs;
    private UIManager _uiManager;
    private GameManager _gameManager;

    void Awake()
    {
        _savePrefs = GameObject.Find("Save_Game").GetComponent<SavePrefs>();
        if(_savePrefs == null)
        {
            Debug.LogError("SavePrefs on GamePlay is <null>");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _uiManager =  GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("The UIManager on GamePlay is <null>");
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(_gameManager == null)
        {
            Debug.LogError("The GameManager on GamePlay is <null>");
        }

        _savePrefs.LoadGame();
        guessRight = _savePrefs.sliderValueToSave; 
        Guess();
        _uiManager.UpdatePredictionLimit(guessRight);
    }

    public void Increase()
    {
        if(downLimit < (topLimit-1))
        {
            downLimit = guess + 1;
            Guess();
        }
        else
        {
            downLimit = guess;
        }
    }

    public void Decrease()
    {
        if(topLimit > (downLimit+1))
        {
            topLimit = guess;
            Guess();
        }
    }

    public void Correct()
    {
        _gameManager.GameOver();
        if(guessNumber > guessRight)
        {
            _uiManager.UpdateWinLose("Oyunu siz kazandınız");
            Debug.Log("You have won the game.");
        }
        else
        {
            _uiManager.UpdateWinLose("Oyunu PC kazandı");
            Debug.Log("PC has won the game.");
        }       
    }

    public void Guess()
    {
        guessNumber++;
        _uiManager.UpdatePredictionNo(guessNumber);
        int randomInt = Random.Range(downLimit,topLimit);
        guess = randomInt;
        _uiManager.UpdatePrediction(guess);
        Debug.Log("downlimit= " + downLimit + ", toplimit= " + topLimit + ", guess= " + guess);
    }
}
