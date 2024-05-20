using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
  
    public Score score;
    public bool isFire;

    [SerializeField]
    float speed;
    Vector2 direction;
 
   
    private void Start()
    {

        direction = new Vector2(0.1f, 1.0f).normalized;
    }

    private void Update()
    {

        if (isFire)
        transform.Translate(direction * speed * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("brick"))
        {
            SoundManager.instance.PlaySE("brick");
            //// 충돌 지점의 노멀 벡터를 가져옵니다.
            Vector2 normal = collision.contacts[0].normal;
            //// 방향 벡터를 충돌 지점의 노멀 벡터를 기준으로 반사합니다.
            direction = Vector2.Reflect(direction.normalized, normal);
            
            
         }

        if (collision.gameObject.CompareTag("death"))
        {
            Destroy(this.gameObject);
            Debug.Log("BallOut!");
            GameManager.Instance.GameOver();
        }
    }
}
