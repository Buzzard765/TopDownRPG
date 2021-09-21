using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [Header("UI Section")]
    private Image itemImage;
    private Text stockText;
    [Header("Item Variable Section")]
   
    public string description;
    public ItemObject thisItem;
    public InventoryManager thisManager;

    private Inventory ivtrSlot;
    public int slotnumber;
    // Start is called before the first frame update

    public void setup(ItemObject newItem, InventoryManager newManager) {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem) {
            itemImage.sprite = thisItem.itemimage;
            stockText.text = "" + thisItem.held;
        }
    }
    void Start()
    {
        ivtrSlot = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0) {
            ivtrSlot.isFull[slotnumber] = false;
        }
    }

    public void DropItem() {
        foreach (Transform child in transform) {
            child.GetComponent<ItemScript>().DropItem();
            GameObject.Destroy(child.gameObject);
            Debug.Log("You Dropped an item");
        }
    }
}
