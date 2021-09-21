using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public enum playerstate {
        movement,
        attack,
        interact,
    }
    public playerstate currentstate;
    public float movespeed;
    public Rigidbody2D playerRB;
    private Vector2 direction;

    private Animator animator;

    public int MaxHealth, MaxAP;
    public int Health, AbilityPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        currentstate = playerstate.movement;
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

        Health = MaxHealth;
        AbilityPoints = MaxAP;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        PlayerMovement();
        AniUpdate();
    }

    void PlayerMovement() {
        playerRB.MovePosition(playerRB.position + direction * movespeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.S) && currentstate != playerstate.attack)
        {
            StartCoroutine(Attack());
        }
        else if (currentstate == playerstate.movement) {
            AniUpdate();
        }       
    }

    private IEnumerator Attack() {
        animator.SetBool("Attack", true);
        currentstate = playerstate.attack;
        yield return null;
        animator.SetBool("Attack", false);       
        yield return new WaitForSeconds(0.33f);
        currentstate = playerstate.movement;
    }

    void AniUpdate() {
        if (direction != Vector2.zero) {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Idle", true);
        }   

    }

    public void Damage(float value) {
        Health = (int)Mathf.Clamp(Health - value, 0f, 0);
    }
    public void Recovery(float value)
    {
        Health = (int)Mathf.Clamp(Health + value, 0f, MaxHealth);
    }
    public void Siphon(float value) {
        AbilityPoints = (int)Mathf.Clamp(AbilityPoints - value, 0f, 0);
    }
    public void Rejuvenate(float value) {
        AbilityPoints = (int)Mathf.Clamp(Health + value, 0f, MaxHealth);
    }



}
