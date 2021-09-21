using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Item", menuName = "Item")]
public class ItemObject : ScriptableObject
{
    public string itemname, description;
    public Sprite itemimage;
    public int held;   
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
