using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public LifeUI lifeUI;
    public MakeBrick makeBrick;

    public GameObject ball;
    public Ball ballSc;

    public Transform paddleTr;
    public GameObject paddle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void UseItem(string itemName)
    {
        switch (itemName)
        {
            case "item0":
                GameObject[] ballSizeUp = GameObject.FindGameObjectsWithTag("ball");
                foreach (var ball in ballSizeUp)
                {
                    ball.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                break;
            case "item1":
                GameObject[] brick = GameObject.FindGameObjectsWithTag("brick");
                Destroy(brick[Random.Range(0,makeBrick.brickList.Count)]);
                GameManager.Instance.RemoveRandomBrick();
                break;
            case "item2": paddle.GetComponent<SideMovement>().speed = 15;
                break;
            case "item3":
                GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
                foreach (var ball in balls)
                {
                    for (int i = 0; i<4; i++)
                    {
                        GameObject makeBall = Instantiate(ball);
                        makeBall.transform.position = new Vector2(ball.transform.position.x + Random.Range(-1,1f), ball.transform.position.y);
                        makeBall.transform.localScale = new Vector3(0.5f, 0.5f ,1f);
                        makeBall.GetComponent<Ball>().isTempBall = true;
                    }
                }
                break;
            case "item4":
                lifeUI.LoseLife();
                GameObject[] ballSizeReturn = GameObject.FindGameObjectsWithTag("ball");
                foreach(var ball in ballSizeReturn)
                {
                    ball.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                }
                break;
            case "item5":
                break;
            case "item6":
                paddleTr.transform.localScale = new Vector3(1f,0.5f,1f);
                break;
            case "item7":
                paddleTr.transform.localScale = new Vector3(0.3f, 0.5f, 1f);
                break;
        }
    }
}
