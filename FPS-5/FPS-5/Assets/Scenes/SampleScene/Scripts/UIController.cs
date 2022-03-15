using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreValue;
    // Start is called before the first frame update
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopUp optionsPopUp;
    [SerializeField] private SettingsPopUp settingsPopUp;


    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
    }

    private void OnEnemyDead()
    {
        score++;
        UpdateScore(score);
    }
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
        Debug.Log("Score?");
    }
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            crossHair.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            crossHair.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        UpdateScore(score);
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !optionsPopUp.IsActive() && !settingsPopUp.IsActive())
        {
            optionsPopUp.Open();
            SetGameActive(false);
        }
    }
}
