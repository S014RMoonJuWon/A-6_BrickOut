using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float fallSpeed = 5f;

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
        itemSr.sprite = Resources.Load<Sprite>($"Images/Item/Item{Random.Range(0,8)}");
    }

    void UseItem()
    {
        string itemName = itemSr.sprite.name;
        ItemManager.Instance.UseItem(itemName);
    }
}
