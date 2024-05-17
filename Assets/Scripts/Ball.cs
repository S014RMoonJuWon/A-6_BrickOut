using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    public bool isFire;

    Vector2 direction = Vector2.zero;

    private void Start()
    {
        direction = Vector2.up.normalized;
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
            // �浹 ������ ��� ���͸� �����ɴϴ�.
            Vector2 normal = collision.contacts[0].normal;
            // ���� ���͸� �浹 ������ ��� ���͸� �������� �ݻ��մϴ�.
            direction = Vector2.Reflect(direction, normal).normalized;
        }
    }
}
