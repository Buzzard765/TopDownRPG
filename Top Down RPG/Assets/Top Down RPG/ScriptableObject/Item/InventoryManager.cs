using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Info")]
    [SerializeField] private GameObject EmptySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject UseButton;
    [SerializeField] private Text descText;

    public void setTextAndButton(string description, bool isActive) {
        descText.text = description;
        if (isActive == true)
        {
            UseButton.SetActive(true);
        }
        else {
            UseButton.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setTextAndButton("", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
