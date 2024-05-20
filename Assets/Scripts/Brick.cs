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
    public void BrickColor(int color)
    {
        brickRenderer.sprite = Resources.Load<Sprite>($"Images/Bricks/brick{color}");
        life = color;
        score = 10 * (color + 1);
    }
}
