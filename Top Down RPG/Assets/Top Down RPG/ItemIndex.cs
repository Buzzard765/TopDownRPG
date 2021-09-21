using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIndex : MonoBehaviour
{
    public int[] itemstock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int price, int itemstock) {

    }

    public void Combine(int item1, int item2) {
        if (itemstock[item1] <= 0 || itemstock[item2] <= 0) {
            itemstock[item1] -= 1;
            itemstock[item2] -= 1;
        }
        
    }
}
