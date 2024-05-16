using UnityEditor;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    private PaddleController controller;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

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

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        movementRigidbody.velocity = direction;
    }
}
