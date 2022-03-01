using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ReactToHit()
    {
        WanderingAI enemyAI = GetComponent<WanderingAI> ();
        if (enemyAI != null)
        {
            enemyAI.ChangeState(EnemyStates.dead);
        }
        Animator enemyAnimator = GetComponent<Animator> ();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("die");
        }
       // StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(1);

       // Destroy(this.gameObject);
    }
    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
