using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int maxHealth = 5;
    private int health;
    // Start is called before the first frame update
    
    void Start()
    {
        health = maxHealth;       
    }
    public void Hit()
    {
        Messenger.Broadcast(GameEvent.HEALTH_CHANGED);
        health -= 1;
        
        Debug.Log("Health: " + health);
        if(health == 0)
        {
            Debug.Break();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
