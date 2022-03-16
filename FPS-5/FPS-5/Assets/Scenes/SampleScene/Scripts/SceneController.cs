using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private int numOfEnemies = 5; 
    private GameObject[] bundleOfEnemies;
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;

    private int numOfIguanas = 5;
    private GameObject[] messOfIguanas;
    [SerializeField] private GameObject iguanaPrefab;
    private GameObject iguana;
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
       // Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        //Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);

    }

    //void OnHealthChanged(float healthPercent)
    //{
    //    Debug.Log("Health changed to: ");//+ healthPercent);
    //}
    void OnDifficultyChanged(int newDifficulty)
    {
        Debug.Log("Scene.difficultyChanged(" + newDifficulty + ")");
        for(int i=0; i<bundleOfEnemies.Length; i++)
        {
            WanderingAI ai = bundleOfEnemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }
    int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }
    void Start()
    {
        bundleOfEnemies = new GameObject[numOfEnemies];
        messOfIguanas = new GameObject[numOfIguanas];
       for(int i = 0; i < numOfIguanas; i++)
        {
            iguana = Instantiate(iguanaPrefab) as GameObject;
            messOfIguanas[i] = iguana;
            iguana.transform.position = new Vector3(-3.15f, 0, 7.55f);
            float angle = Random.Range(0, 360);
            iguana.transform.Rotate(0, angle, 0);
        }
           

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            if (bundleOfEnemies[i] == null)
            {
                
                enemy = Instantiate(enemyPrefab) as GameObject;
                bundleOfEnemies[i] = enemy;
                WanderingAI ai = bundleOfEnemies[i].GetComponent<WanderingAI>();
                ai.SetDifficulty(GetDifficulty());
                enemy.transform.position = new Vector3(0, 0, 5);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
            }


        }
       
    }
}
