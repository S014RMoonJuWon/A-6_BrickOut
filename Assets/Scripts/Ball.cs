using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
  
    public Score score;
    public bool isFire;
    [SerializeField]
    int lifeCount;
    public LifeUI lifeUI;

    [SerializeField]
    float speed;
    [SerializeField]
    Transform ballPosion;
    [SerializeField]
    Transform paddle;

    Vector2 direction;
    Vector2 firstDir; //처음 방향을 받을 벡터
   
    private void Start()
    {
        
        lifeCount = GameManager.Instance.lifeCount;
        firstDir   = new Vector2(0.1f, 1.0f).normalized;
        direction = firstDir;

    }

    private void Update()
    {

        if (isFire)
        transform.Translate(direction * speed * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("brick") || collision.gameObject.CompareTag("HardBrick"))
        {
            SoundManager.instance.PlaySE("brick");
            //// 충돌 지점의 노멀 벡터를 가져옵니다.
            Vector2 normal = collision.contacts[0].normal;
            //// 방향 벡터를 충돌 지점의 노멀 벡터를 기준으로 반사합니다.
            direction = Vector2.Reflect(direction.normalized, normal);
         
         }

        if (collision.gameObject.CompareTag("death"))
        {
            if (lifeCount > 0)
            {
                lifeCount--;
                lifeUI.LoseLife();

                isFire = false;
                transform.position = ballPosion.transform.position;
                transform.SetParent(paddle);
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                direction = firstDir;
                rb.isKinematic = true;
            }

            if (lifeCount == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("BallOut!");
                GameManager.Instance.GameOver();
            }
        }
    }
}
