using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventoryslot;
    public GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
        inventoryslot = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            for (int i = 0; i < inventoryslot.slots.Length; i++) {
                if (inventoryslot.isFull[i] == false) {
                    inventoryslot.isFull[i] = true;
                    Instantiate(itemButton, inventoryslot.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
