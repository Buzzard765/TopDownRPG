using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public ItemObject itemDetail;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropItem() {
        Vector2 playerpos = new Vector2(player.position.x, player.position.y + 3);
        Instantiate(item, playerpos, Quaternion.identity);
    }


}
