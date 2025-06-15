using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    //add a player input component to the gameobject
    //create an input action in the assets, open it
    // add control scheme --> name it keyboard --> make it required --> add keyboard
    // add an action map ==> name it gameplay
    // add an action like fire, modify action type (button), add a binding then path
    // add an action named move, its pass through and control type is vector2,, add a binding (composite) then path
    // add the input action to the player input component
    // set the default scheme to keyboard

    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 _moveDirection;
    public InputActionReference move;
    public InputActionReference fire;


    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);

    }

    //Input System doesn't automatically enable actions
    //OnEnable() and OnDisable() are Unity lifecycle methods 
    // OnEnable() runs when the GameObject becomes active (e.g., when the scene starts or the script is enabled). 
    // OnDisable() runs when the GameObject is disabled (e.g., when switching scenes or disabling the script). 
    // This ensures the Input Action is only active when needed.
    private void OnEnable()
    {
        move.action.Enable();
        fire.action.Enable();
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        move.action.Disable();
        fire.action.Disable();
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
    }
}
