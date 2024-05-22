using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1f;

    public SpriteRenderer itemSr;

    void Start()
    {
        fallSpeed = DataManager.instance.level + fallSpeed;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            Destroy(this.gameObject);
        }

        if (ItemManager.Instance.ballSc.isFire == false)
        {
            return;
        }

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
