/*
Property of StupidGirlGames @Daniel James Tarplett.
Copying or redistribution is prohibited without written concent.
*/

using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
/// The playercontroller defines the interface between the human player and the 
/// gameobject he/she wishes to control. This is by getting input from the playerInput
/// component and sending queries to the animator statemachine and it's behaviours. 
///</summary>
public class PlayerController2D : CharacterController2D
{
    [Tooltip("Collider that disables when crouching")]
    public Collider2D crouchDisableCollider;

    // These values are made public for ease of use by the component
    // or script controlling the players movement. They are the results
    // from the players input actions.
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public bool running;
    [HideInInspector] public bool jumping;
    [HideInInspector] public bool attacking;
    [HideInInspector] public bool acting;

    private PlayerInput playerInput;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movement = Vector2.zero;
        running = false;
        jumping = false;
        attacking = false;
        acting = false;

    }

    ///<summary>
    /// Move the player left or right and check if the player should crouch
    /// based on the vector2 composite inputaction.
    ///<summary>
    public void HandleMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    ///<summary>
    /// Ask the player to run.
    ///</summary>
    public void HandleRun(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            running = true;
        }
        else
        {
            running = false;
        }
        
    }

    ///<summary>
    /// Ask the player to jump or abort an ongoing jump
    ///<summary>
    public void HandleJump(InputAction.CallbackContext context)
    {
        if(context.performed || context.canceled)
        {
            
            jumping = false;
        }

        else
        {
            jumping = true;
        }   
    }

    ///<summary>
    /// Ask the player to do an attack.
    ///</summary>
    public void HandleAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }

    ///<summary>
    /// Ask the player to perform an action
    ///<summary>
    public void HandleAction(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            acting = true;
        }
        else
        {
            acting = false;
        }
    }

}
