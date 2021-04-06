using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerLook playerLook;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PauseMenu pauseMenu;

   GameInput gameInput;
   GameInput.PlayerActions playerActions;
   GameInput.UIActions uIActions;
   
   Vector2 horizontalInput;
   Vector2 rawLookInput;

    private void Awake(){
        //Setup variables
        gameInput = new GameInput();
        playerActions = gameInput.Player;
        uIActions = gameInput.UI;

        //Read look input
        playerActions.lookX.performed += ctx => rawLookInput.x = ctx.ReadValue<float>();
        playerActions.lookY.performed += ctx => rawLookInput.y = ctx.ReadValue<float>();

        //Read movement input
        playerActions.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        //Read sprint and jump input
        playerActions.Jump.performed += _ => playerMove.JumpEvent();
        playerActions.Sprint.started += _ => playerMove.SprintEvent(true);
        playerActions.Sprint.canceled += _ => playerMove.SprintEvent(false);

        //Read pause input
        uIActions.Pause.performed += _ => pauseMenu.PauseEvent();
    }

    private void Update(){
        //Send axis data to playerLook and playerMove
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