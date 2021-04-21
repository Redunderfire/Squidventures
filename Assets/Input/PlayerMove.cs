using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [System.NonSerialized]public float currentFuel; //needs to be public for HUD to access

    [Header("Movement Settings")]
    [SerializeField]private float walkingSpeed = 7f;
    [SerializeField]private float runningSpeed = 9.5f;
    [SerializeField]private float jumpHeight = 3f;
    [SerializeField]private float gravity = -9.81f;

    [Header("Jetpack Settings")]
    [SerializeField]private float maxFuel = 100f;
    [SerializeField]private float fuelReduce = 18f;
    [SerializeField]private float fuelGain = 14f;
    [SerializeField]private float baseJetpackVelocity = 1f;
    [SerializeField]private float jetpackAcceleration = 1.1f;
    [SerializeField]private float terminalVelocity = 2.5f;
    
    [Header("Ground Detection")]
    [SerializeField]private float groundDistance = 0.4f;
    [SerializeField]private LayerMask groundMask;

    private CharacterController controller;
    private bool isGrounded, jump, boost;
    private float x, z, speed, jetpackVelocity;
    private Vector3 yVelocity = Vector3.zero;

    // Sets speed at beginning, consequence of the way Unity handles floats outside of this scope
    private void Start(){
        SprintEvent(false);
        controller = this.GetComponent<CharacterController>();
        currentFuel = maxFuel;
    }
    //Update is called once per frame
    private void Update(){
        //Ground Checks, velocity adjustment, and fuel gain
        isGrounded =  isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (isGrounded && !boost){
            if(currentFuel < maxFuel){
            currentFuel += fuelGain*Time.deltaTime;
            } else {
                currentFuel = maxFuel;
            }

            if(yVelocity.y < 0){
                yVelocity.y = 0f;   
            }
        }

        if (yVelocity.y > terminalVelocity){ //clamp velocity
            yVelocity.y = terminalVelocity;
        }

        //Move forward, left, and right
       Vector3 move = new Vector3(x, 0, z); 
       move = transform.TransformDirection(move.normalized);
       controller.Move(move * Time.deltaTime * speed);

        //jump
        if(jump){
            yVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            jump = false;
        }

        //boost
        if(boost && currentFuel > 0.00f){
             yVelocity.y += 1.0f * jetpackVelocity;
             jetpackVelocity += Mathf.Pow(jetpackAcceleration, 2) * Time.deltaTime; 
             currentFuel -= fuelReduce*Time.deltaTime;
        } else {
            jetpackVelocity = baseJetpackVelocity;
        }

        yVelocity.y += gravity * Time.deltaTime;
        controller.Move(yVelocity * Time.deltaTime);
    }

    //Receive input from InputManager
    public void ReceiveInput(Vector2 input){
        x = input.x;
        z = input.y;
    }

    //Set jump
    public void JumpEvent(bool pressed) {
        if(pressed){
            if(isGrounded){
                jump = true;
                boost = false;
            } else {
                jump = false;
                boost = true;
            }
        }
        if(!pressed){
                jump = false;
                boost = false;
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
