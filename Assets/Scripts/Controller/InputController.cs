using UnityEngine.InputSystem;
using UnityEngine;

public class InputController : PaddleController
{
    
    private SideMovement sideMovement;

    private void Awake()
    {
        sideMovement = GetComponent<SideMovement>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire(InputValue value)
    {
        sideMovement.ApplyFire(value.isPressed);
    }
}