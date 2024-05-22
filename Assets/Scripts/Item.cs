using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float fallSpeed = 1f;

    public SpriteRenderer itemSr;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            UseItem();
            Destroy(this.gameObject);
        }
    }
    public void ItemImages()
    {
        itemSr.sprite = Resources.Load<Sprite>($"Images/Item/Item{3}");
    }

    void UseItem()
    {
        string itemName = itemSr.sprite.name;
        ItemManager.Instance.UseItem(itemName);
    }
}
