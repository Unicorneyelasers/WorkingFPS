using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopUp : BasePopUp
{
    [SerializeField] private UIController controller;
    [SerializeField] private SettingsPopUp settings;
    //public void Open()
    //{
    //    gameObject.SetActive(true);
    //}
   
    //public void Close()
    //{
    //    gameObject.SetActive(false);
    //}

    //public bool IsActive()
    //{
    //    return gameObject.activeSelf;
    //}
    public void OnSettingsButton()
    {
        Close();
        settings.Open();
        Debug.Log("Settings clicked");
        
    }

    public void OnExitGameButton()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        controller.SetGameActive(true);
        Close();
    }
}
