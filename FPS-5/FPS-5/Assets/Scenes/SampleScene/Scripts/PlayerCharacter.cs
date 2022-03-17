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
        health--;
        float healthPercent = (float)health / (float)maxHealth;
        Debug.Log("hit:" + health + ", " + maxHealth + ": " + healthPercent);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED,healthPercent);
       // health -= 1;
        
        //Debug.Log("Health: " + health);
        //if(health == 0)
        //{
        //    Debug.Break();
        //}
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
