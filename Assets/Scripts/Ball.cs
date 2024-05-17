using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody;
    public bool isFire;

    Vector2 direction = Vector2.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        direction = Vector2.up.normalized;
    }

    private void Update()
    {
        if (isFire)
            transform.Translate(direction * speed * Time.deltaTime);
       
    }
    void Launch()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.up * speed;
        direction = _rigidbody.velocity;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("brick"))
        {

            Debug.Log("들어옴");
            Debug.Log(collision.ToString());
            // 충돌 지점의 노멀 벡터를 가져옵니다.
            Vector2 normal = collision.contacts[0].normal;
            // 방향 벡터를 충돌 지점의 노멀 벡터를 기준으로 반사합니다.
            direction = Vector2.Reflect(direction, normal).normalized;

        }
    }
}
