using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    private Slider slider;
    private Text textComp;
    private float defaultValue = 10;

    private SavePrefs _savePrefs;

    void Awake()
    {
        slider = GetComponentInParent<Slider>();
        textComp = GetComponent<Text>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        _savePrefs = GameObject.Find("Save_Game").GetComponent<SavePrefs>();
        if(_savePrefs == null)
        {
            Debug.LogError("SavePrefs on SliderValueText is <null>");
        }
        _savePrefs.LoadGame();
        slider.value = _savePrefs.sliderValueToSave;
        UpdateText(slider.value);
        slider.onValueChanged.AddListener(UpdateText);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText(float val)
    {
        textComp.text = slider.value.ToString();
        _savePrefs.sliderValueToSave = slider.value;
        _savePrefs.SaveGame();
    }

    public void UpdateTextToDefault()
    {
        slider.value = defaultValue;
        _savePrefs.sliderValueToSave = slider.value;
        _savePrefs.SaveGame();
    }
}
