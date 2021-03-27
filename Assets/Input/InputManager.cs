using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerLook playerLook;
    [SerializeField] PlayerMove playerMove;

   GameInput gameInput;
   GameInput.PlayerActions playerActions;
   
   Vector2 horizontalInput;
   Vector2 rawLookInput;

    private void Awake(){
        //Setup variables
        gameInput = new GameInput();
        playerActions = gameInput.Player;

        //Read look input
        playerActions.lookX.performed += ctx => rawLookInput.x = ctx.ReadValue<float>();
        playerActions.lookY.performed += ctx => rawLookInput.y = ctx.ReadValue<float>();
        playerActions.Jump.performed += _ =>    playerMove.JumpEvent();
        //Read movement input
        playerActions.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    private void Update(){
        playerLook.ReceiveInput(rawLookInput);
        playerMove.ReceiveInput(horizontalInput);
    }

#region Enable and disable controls on start and exit
    private void OnEnable(){
        gameInput.Enable();
    }

    private void OnDisable(){
        gameInput.Disable();
    }
#endregion
}