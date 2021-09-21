using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Patrol,
    Walk,
    Attack,
    Stagger
}

public class EnemyScript : MonoBehaviour
{
    

    public EnemyState CurrentState;
    public EnemyStats enemystats;
    public string CreatureName;
    private int health;
    public int  baseattack;
    public float speed;

    public Rigidbody2D rb2d;


    private void Awake()
    {
        health = enemystats.MaxHealth;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void knockbackdamage(Rigidbody2D myRB, float knocktime) {
        StartCoroutine(Knockdelay(myRB, knocktime));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private IEnumerator Knockdelay(Rigidbody2D enemy, float knocktime)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knocktime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<EnemyScript>().CurrentState = EnemyState.Patrol;
        }
    }
}
