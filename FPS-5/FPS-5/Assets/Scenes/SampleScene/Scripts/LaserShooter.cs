using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player != null)
        {
            player.Hit();
        }
        Destroy(this.gameObject);
    }
}
