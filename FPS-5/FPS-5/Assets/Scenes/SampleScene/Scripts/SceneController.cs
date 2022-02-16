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
    // Start is called before the first frame update
    void Start()
    {
        bundleOfEnemies = new GameObject[numOfEnemies];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfEnemies; i++) {
            if (bundleOfEnemies[i] == null){
            enemy = Instantiate (enemyPrefab) as GameObject;
            bundleOfEnemies[i] = enemy;
            enemy.transform.position = new Vector3(0, 0, 5);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            }
    }
        // if (enemy == null)
        // {
        //     enemy = Instantiate (enemyPrefab) as GameObject;
        //     enemy.transform.position = new Vector3(0, 0, 5);
        //     float angle = Random.Range(0, 360);
        //     enemy.transform.Rotate(0, angle, 0);
        // }
    }
}
