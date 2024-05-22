using UnityEngine;


public class Brick : MonoBehaviour
{
    public SpriteRenderer brickRenderer;
    private int life;
    private int score;

    public GameObject item;
    public Item itemSc;

    void OnCollisionEnter2D(Collision2D collision)
    {
        string spriteName = brickRenderer.sprite.name;
        life--;
        if (life == 0)
        {
            int num = Random.Range(0, 100);
            GameManager.Instance.GetScore(score);
            switch (spriteName)
            {
                case "brick0":
                    if (num < 15) InstantiateItem();
                    break;
                case "brick1":
                    if (num < 30) InstantiateItem();
                    break;
                case "brick2":
                    if (num < 45) InstantiateItem();
                    break;
                case "brick3":
                    if (num < 60) InstantiateItem();
                    break;
                case "brick4":
                    InstantiateItem();
                    break;
            }
            Destroy(this.gameObject);
        }
    }
    public void BrickOption(int color)
    {
        brickRenderer.sprite = Resources.Load<Sprite>($"Images/Bricks/brick{color}");
        life = color + 1;
        score = 10 * (color + 1);
    }
    public void AddTag(int brick)
    {
        if (brick == 0) this.gameObject.tag = "DeleteBrick";
        else if (brick == 6) 
        {
            this.gameObject.tag = "HardBrick";
            brickRenderer.color = new(62f/255f, 4f/255f, 72f/255f);
        }
    }
    public void InstantiateItem()
    {
        GameObject makeItem = Instantiate(item, this.transform);
        makeItem.transform.SetParent(null);
        makeItem.transform.position = this.transform.position;
        itemSc.ItemImages();
    }
}
