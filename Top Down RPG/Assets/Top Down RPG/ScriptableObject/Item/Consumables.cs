using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : ItemScript 
{
    public int recoveryAmount;
    private TopDownMovement PlayerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecoverHealth() {
        PlayerStats.Recovery(recoveryAmount);
        Destroy(gameObject);
    }

    public void RecoverAP() {
        PlayerStats.Rejuvenate(recoveryAmount);
        Destroy(gameObject);
    }
}
