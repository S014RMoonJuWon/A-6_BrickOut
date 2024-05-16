using UnityEngine.InputSystem;
using UnityEngine;

public class InputController : PaddleController
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }
}