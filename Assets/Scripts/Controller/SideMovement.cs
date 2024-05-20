using System;
using UnityEditor;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    private PaddleController controller;
    private Rigidbody2D movementRigidbody;
    [SerializeField]
    private GameObject ball;
    Rigidbody2D rb;

    private Vector2 movementDirection = Vector2.zero;
    public bool isFire { get;private set; }

    [SerializeField] private float speed = 10;

    private void Awake()
    {
        rb = ball.GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // 공이 발사되기 전에는 물리적 영향을 받지 않도록 설정    
        controller = GetComponent<PaddleController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        //transform.position =new Vector2( Mathf.Clamp(transform.position.x, -7.6f, 7.7f),transform.position.y);
        movementRigidbody.velocity = direction;
    }

    internal void ApplyFire(bool isPressed)
    {
        if (isPressed)
        {
            isFire = isPressed;
            rb.isKinematic = false;
            ball.GetComponent<Ball>().isFire = true;
            ball.transform.parent = null;
        }
    }
}
