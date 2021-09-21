using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float push, knockbacktime;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null) {
                enemy.GetComponent<EnemyScript>().CurrentState = EnemyState.Stagger;
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * push;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                
                StartCoroutine(Knockdelay(enemy));
            }
        }
    }

    private IEnumerator Knockdelay(Rigidbody2D enemy) {
        if (enemy != null) {
            yield return new WaitForSeconds(knockbacktime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<EnemyScript>().CurrentState = EnemyState.Patrol;
            enemy.isKinematic = true;
        }
    }
}
