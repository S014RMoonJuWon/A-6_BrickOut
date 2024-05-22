using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public GameObject ball;
    public Ball ballSc;

    public List<GameObject> balls = new List<GameObject>();

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
                break;
            case "item1":
                break;
            case "item2":
                break;
            case "item3":
                GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
                foreach (var ball in balls)
                {
                    GameObject makeBall = Instantiate(ball);
                    makeBall.transform.SetParent(null);
                    makeBall.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y - 2f);
                }
                break;
            case "item4":
                break;
            case "item5":
                break;
            case "item6":
                break;
            case "item7":
                break;
        }
    }
    public void MakeBall()
    {
        Debug.Log("BALL2");
        GameObject makeBall = Instantiate(ball, ballSc.ball2Posion);
        makeBall.transform.SetParent(null);
    }
}
