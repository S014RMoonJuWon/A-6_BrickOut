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
        movementRigidbody.velocity = direction;
    }

    internal void ApplyFire(bool isPressed)
    {
        

        if (rb == null)
        {
            isFire = isPressed;
            rb = ball.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            ball.GetComponent<Ball>().isFire = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            ball.transform.parent = null;
        }
     
    }
}
