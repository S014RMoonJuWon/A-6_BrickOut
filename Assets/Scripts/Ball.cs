using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _rigidbody;

    Vector2 direction = Vector2.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        direction = Vector2.up.normalized;
       
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("brick"))
        { 
            // 충돌 지점의 노멀 벡터를 가져옵니다.
            Vector2 normal = collision.contacts[0].normal;
            // 방향 벡터를 충돌 지점의 노멀 벡터를 기준으로 반사합니다.
            direction = Vector2.Reflect(direction, normal).normalized;
            Vector2 vector2 = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, vector2).normalized;

        }
    }
}
