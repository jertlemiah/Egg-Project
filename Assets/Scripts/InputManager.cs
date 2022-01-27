using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private InputActions inputActions;
    // private static InputManager _instance;


    public static InputManager Instance {
        get {
            return _instance;
        }
    }

    void Awake()
    {
        // There should only ever be one InputManager. May implement singleton later.
        // if (_instance != null && _instance != this) {
        //     Destroy(this.gameObject);
        // } else
        // {
        //     _instance = this;
        // }
        inputActions = new InputActions();
        //Cursor.visible = false;
    }

    public InputActions GetInputActions()
    {
        return inputActions;
    }

    public Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumpedThisFrame()
    {
        return inputActions.Player.Jump.triggered;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
