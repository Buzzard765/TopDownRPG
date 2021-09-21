using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private Inventory ivtrSlot;
    public int slotnumber;
    // Start is called before the first frame update
    void Start()
    {
        ivtrSlot = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            ivtrSlot.isFull[slotnumber] = false;
        }
    }

    public void Drop()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<ItemScript>().DropItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
