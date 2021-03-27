using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    [SerializeField] public float walkingSpeed = 7f;
    [SerializeField] public float runningSpeed = 9.5f;
    [SerializeField] public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded, jump;
    float x, z, speed;
       
    Vector3 velocity;

    // Sets speed at beginning, consequence of the way Unity handles floats outside of this scope
    private void Start(){
        SprintEvent(false);
    }
    //Update is called once per frame
    private void Update()
    {
        //Check for ground collision with the player
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        //Grounding logic
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //Jump logic
        if(jump){
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            jump = false;
        }

        velocity.y += gravity * Time.deltaTime; //Update Gravity
        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * speed * Time.deltaTime); //Apply horizontal movement
        controller.Move(velocity * Time.deltaTime); //Apply vertical velocity
    }

    //Receive input from InputManager
    public void ReceiveInput(Vector2 input){
        x = input.x;
        z = input.y;
    }

    //Set jump
    public void JumpEvent() {
        if(isGrounded){
            jump = true;
        } else {
            jump = false;
        }
    }

    //Set speed
    public void SprintEvent(bool sprinting){
        if (sprinting && isGrounded) {
            speed = runningSpeed;
        } else {
            speed = walkingSpeed;
        }
    }
}
