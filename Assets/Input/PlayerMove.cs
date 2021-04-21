using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private CharacterController _controller;
    public float _fuel;

    [SerializeField] public float walkingSpeed = 7f;
    [SerializeField] public float runningSpeed = 9.5f;
    [SerializeField] public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float maxFuel = 100f;
    public float fuelReduce = 100f;
    public float fuelGain = 10f;
    public float baseJetpackVelocity = 1.5f;
    public float jetpackAcceleration = 1f;
    public float terminalVelocity = 2f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded, jump, boost;
    private float x, z, speed, jetpackVelocity;
    private Vector3 yVelocity = Vector3.zero;

    // Sets speed at beginning, consequence of the way Unity handles floats outside of this scope
    private void Start(){
        SprintEvent(false);
        _controller = this.GetComponent<CharacterController>();
        _fuel = maxFuel;
    }
    //Update is called once per frame
    private void Update()
    {
        //Ground Checks and velocity adjustment
        isGrounded =  isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (isGrounded && !boost){
            if(_fuel < maxFuel){
            _fuel += fuelGain*Time.deltaTime;
            } else {
                _fuel = maxFuel;
            }
            if(yVelocity.y < 0){
                yVelocity.y = 0f;   
            }

        }
        if (yVelocity.y > terminalVelocity){ //clamp velocity
            yVelocity.y = terminalVelocity;
        }

       Vector3 move = new Vector3(x, 0, z);
       move = transform.TransformDirection(move.normalized);
       _controller.Move(move * Time.deltaTime * speed);

        if(jump){
            yVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            jump = false;
        }

        if(boost && _fuel > 0.00f){
             yVelocity.y += 1.0f * jetpackVelocity;
             jetpackVelocity += Mathf.Pow(jetpackAcceleration, 2) * Time.deltaTime; 
             _fuel -= fuelReduce*Time.deltaTime;
        } else {
            jetpackVelocity = baseJetpackVelocity;
        }

        yVelocity.y += gravity * Time.deltaTime;
        _controller.Move(yVelocity * Time.deltaTime);

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
                Debug.Log("jump event logged");  
            } else {
                jump = false;
                boost = true;
                Debug.Log("boost event logged");
            }
        }
        if(!pressed){
            Debug.Log("Jump events canceled");
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
