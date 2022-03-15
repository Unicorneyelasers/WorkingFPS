using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsPopUp : BasePopUp
{
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private OptionsPopUp optionsPopUp;
    //[SerializeField] private 
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void OnOkButton()
    {
        PlayerPrefs.SetInt("difficulty", ((int)difficultySlider.value));
        Debug.Log("Ok clicked");
        Close();
        optionsPopUp.Open();
    }
    public void OnCancelButton()
    {
        Close();
        optionsPopUp.Open();
       
    }
    override public void Open()
    {
       
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }

    //public void Close()
    //{
    //    gameObject.SetActive(false);
    //}

    //public bool IsActive()
    //{
    //    return gameObject.activeSelf;
    //}
    //// Update is called once per frame
    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " + ((int)difficulty).ToString();
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}
