using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public float sliderValueToSave;

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavedSliderValue", sliderValueToSave);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("SavedSliderValue"))
        {
            sliderValueToSave = PlayerPrefs.GetFloat("SavedSliderValue");
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save date");
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        sliderValueToSave = 0;
        Debug.Log("Data reset complete");
    }

}
