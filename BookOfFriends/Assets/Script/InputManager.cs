using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput PlayerInput;

    public static Vector2 P1Movement; // Stores movement as a vector input. Useful if you want to convert this into topdown movement
    public static bool P1JumpWasPressed; // Stores whether the jump button was pressed this frame
    public static bool P1JumpIsHeld; // Stores whether the jump button is being held down
    public static bool P1JumpWasReleased; // Stores whether the jump button was released this frame
    public static bool InteractWasPressed; //stores whether interact was pressed this frame

    public static Vector2 P2Movement;
    public static bool P2JumpWasPressed;
    public static bool P2JumpIsHeld;
    public static bool P2JumpWasReleased;

    private InputAction _P1MoveAction;
    private InputAction _P1JumpAction;
    private InputAction _P2MoveAction;
    private InputAction _P2JumpAction;
    private InputAction _InteractAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _P1MoveAction = PlayerInput.actions["P1_Move"];
        _P1JumpAction = PlayerInput.actions["P1_Jump"];
        _P2MoveAction = PlayerInput.actions["P2_Move"];
        _P2JumpAction = PlayerInput.actions["P2_Jump"];
        _InteractAction = PlayerInput.actions["Interact"];
    }

    // During the update action phase, we read the input values and store them in the static variables for use in other scripts
    private void Update()
    {
        P1Movement = _P1MoveAction.ReadValue<Vector2>();

        P1JumpWasPressed = _P1JumpAction.WasPressedThisFrame();
        P1JumpIsHeld = _P1JumpAction.IsPressed();
        P1JumpWasReleased = _P1JumpAction.WasReleasedThisFrame();
        InteractWasPressed = _InteractAction.WasPressedThisFrame();

        P2Movement = _P2MoveAction.ReadValue<Vector2>();
        P2JumpWasPressed = _P2JumpAction.WasPressedThisFrame();
        P2JumpIsHeld = _P2JumpAction.IsPressed();
        P2JumpWasReleased = _P2JumpAction.WasReleasedThisFrame();
    }
}
