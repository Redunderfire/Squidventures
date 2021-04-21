using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private CharacterController _controller;
    private float _fuel;

    [SerializeField] public float walkingSpeed = 7f;
    [SerializeField] public float runningSpeed = 9.5f;
    [SerializeField] public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float maxFuel = 100f;
    public float fuelReduce = 100f;
    public float jetpackAcceleration = 1.5f;
    public float maxJetpackVelocity = 1.5f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded, jump, boost;
    private float x, z, speed;
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
        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = 0f;
        }
        if (yVelocity.y > maxJetpackVelocity){ //clamp velocity
            yVelocity.y = maxJetpackVelocity;
        }

       Vector3 move = new Vector3(x, 0, z);
       move = transform.TransformDirection(move.normalized);
       _controller.Move(move * Time.deltaTime * speed);

        if(jump){
            yVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            jump = false;
        }
        if(boost){
             yVelocity.y += 1.0f * jetpackAcceleration ;
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
