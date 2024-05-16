using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D _rigidbody;

    Vector2 direction = Vector2.zero;

    private void Start()
    {
        direction = Vector2.up.normalized;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            Vector2 vector2 = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, vector2).normalized;
        }
    }
}
