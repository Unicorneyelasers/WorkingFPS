using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { alive, dead };

public class WanderingAI : MonoBehaviour
{
    private float sphereRadius = 0.75f;
    private float enemySpeed = 1.75f;
    private float obstacleRange = 5.0f;
    private EnemyStates state;
    [SerializeField] 
    private GameObject laserbeamPrefab;
    private GameObject laserbeam;

    public float fireRate = 2.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        state = EnemyStates.alive;
    }

    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;
        Debug.DrawLine(transform.position, rangeTest);
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }

    void Update()
    {
        
        if(state == EnemyStates.alive)
        {
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            //generate ray

            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;
            if (Physics.SphereCast(ray, sphereRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter> ())
                {
                    if (laserbeam == null && Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        laserbeam = Instantiate (laserbeamPrefab) as GameObject;
                        laserbeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                        laserbeam.transform.rotation = transform.rotation;

                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle, 0);
                }
            }
        }
        
    }
}

 