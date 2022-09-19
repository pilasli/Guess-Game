using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text predictionText;
    [SerializeField] private Text predictionLimitText;
    [SerializeField] private Text predictionNoText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text winLoseText;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(_gameManager ==  null)
        {
            Debug.LogError("Game Manager on UI Manager is <null>");
        }

        predictionLimitText.text = "Tahmin Hakkı    : ";
        predictionNoText.text = "Tahmin No          : ";
    }

    public void GameOverSequence()
    {
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            gameOverText.text = "OYUN BİTTİ";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    public void UpdatePrediction(int guess)
    {
        predictionText.text = guess.ToString();
    }

    public void UpdatePredictionLimit(float hak)
    {
        predictionLimitText.text = "Tahmin Hakkı    : " + hak.ToString();
    }

    public void UpdatePredictionNo(int no)
    {
        predictionNoText.text = "Tahmin No          : " + no.ToString();
    }

    public void UpdateWinLose(string winLose)
    {
        winLoseText.text = winLose;
    }


}
