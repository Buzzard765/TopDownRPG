using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightweightEnemy : EnemyScript
{
    

    public Transform target, origin;
    public float chaserange, attackrange;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        CurrentState = EnemyState.Patrol;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        
    }

    void CheckDistance() {
        if (Vector3.Distance(target.position , transform.position) <= chaserange
            && Vector3.Distance(target.position, transform.position) > attackrange) {
            if (CurrentState == EnemyState.Patrol || CurrentState == EnemyState.Walk
                && CurrentState != EnemyState.Stagger) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rb2d.MovePosition(temp);
                ChangeState(EnemyState.Walk);
            }      
        }
    }

    private void ChangeState(EnemyState newstate) {
        if (CurrentState != newstate) {
            CurrentState = newstate;
        }
    }
}
