using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class Ball : MonoBehaviour
{
    private Ball mainBall;

    public Score score;
    public bool isFire;
    public int lifeCount;

    public bool isTempBall;

    [SerializeField] float speed;

    public LifeUI lifeUI;

    public Transform ball2Posion;
    [SerializeField] Transform paddle;

    public Transform ballTr;
    Vector2 direction;
    Vector2 firstDir; //처음 방향을 받을 벡터

    private void Start()
    {
        firstDir   = new Vector2(0.1f, 1.0f).normalized;
        direction = firstDir;
        mainBall = ItemManager.Instance.ball.GetComponent<Ball>();
    }

    private void Update()
    {
        if (!isFire) ballTr.position = new Vector2(paddle.position.x, ball2Posion.position.y);

        if (isFire) transform.Translate (direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("brick") || collision.gameObject.CompareTag("HardBrick"))
        {
            SoundManager.instance.PlaySE("brick");
            // 충돌 지점의 노멀 벡터를 가져옵니다.
            Vector2 normal = collision.contacts[0].normal;
            // 방향 벡터를 충돌 지점의 노멀 벡터를 기준으로 반사합니다.
            direction = Vector2.Reflect(direction.normalized, normal);
        }

        if (collision.gameObject.CompareTag("death"))
        {
            if (isTempBall)
            {
                Destroy(this.gameObject);
                ItemManager.Instance.tempBallCount -= 1;
                if (ItemManager.Instance.tempBallCount == 0 && ItemManager.Instance.isMainBallDead == true)
                {
                    MainBallOut(); // 임시공이 마지막으로 죽었을때
                }
                return;
            }
            if (ItemManager.Instance.tempBallCount > 0)
            {
                this.gameObject.SetActive(false);
                ItemManager.Instance.isMainBallDead = true;
                return;
            }
            MainBallOut(); // 메인공이 마지막에 죽었을 때
        }
    }
    public void MainBallOut()
    {
        if (GameManager.Instance.lifeCount > 0)
        {
            mainBall.gameObject.SetActive(true);
            ItemManager.Instance.isMainBallDead = false;

            lifeUI.LoseLife();
            mainBall.isFire = false;
            mainBall.transform.position = mainBall.ball2Posion.transform.position;
            mainBall.transform.localScale = new Vector3(0.5f, 0.5f, 1f);


            Rigidbody2D rb = mainBall.GetComponent<Rigidbody2D>();
            mainBall.direction = firstDir;
            rb.isKinematic = true;
        }

        if (GameManager.Instance.lifeCount == 0)
        {
            Destroy(mainBall.gameObject);
            Debug.Log("BallOut!");
            GameManager.Instance.GameOver();
        }
    }
}
