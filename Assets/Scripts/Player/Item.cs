using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string type;
    public string modAtt;
    public float modifier;

    private Item thisItem;

    private void Start()
    {
        thisItem = this.gameObject.GetComponent<Item>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerPickup>().PickupItem(thisItem);
            Destroy(this.gameObject, 0f);
        }
    }
}
