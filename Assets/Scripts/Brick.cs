using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Brick : MonoBehaviour
{
    public SpriteRenderer brickRenderer;
    private int life;
    private int score;

    void OnCollisionEnter2D(Collision2D collision)
    {
        string spriteName = brickRenderer.sprite.name;
        switch (spriteName)
        {
            case "brick0":
                Destroy(this.gameObject);
                break;
            case "brick1":
                --life;
                break;
            case "brick2":
                --life;
                break;
            case "brick3":
                --life;
                break;
            case "brick4":
                --life;
                break;
        }
        if (life == 0)
        {
            GameManager.Instance.GetScore(score);
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
}
