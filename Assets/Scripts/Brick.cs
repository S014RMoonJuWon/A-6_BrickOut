using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Brick : MonoBehaviour
{
    public Score score;

    public SpriteRenderer brickRenderer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        score.UpdateScoreText(1);
        Destroy(this.gameObject);
    }
    public void BrickColor(int color)
    {
        brickRenderer.sprite = Resources.Load<Sprite>($"Images/Bricks/brick{color}");
    }
}
