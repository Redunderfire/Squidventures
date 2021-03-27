using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    [SerializeField] public float speed = 12f;
    [SerializeField] public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded, jump;
    float x, z;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        if(jump && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jump = false;
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 input){
        x = input.x;
        z = input.y;
    }

    public void JumpEvent() {
        jump = true;
    }
}
