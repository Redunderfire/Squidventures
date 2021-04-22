using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuModelAnimator : MonoBehaviour
{
    public AnimationCurve yCurve;
    public float ySpeed = 100.0f;
    private float curveDeltaTime = 0.0f;
    private Vector3 initialPosition;



    void Start(){
        initialPosition = transform.position;
    }
    void Update()
    {
        // Get the current position
        Vector3 currentPosition = transform.position;
        //currentPosition.x += speed * Time.deltaTime;
        // Call evaluate on that time   
        curveDeltaTime+= Time.deltaTime;   
        currentPosition.y = initialPosition.y+(ySpeed * yCurve.Evaluate(curveDeltaTime)); 
        // Update the current position
        transform.position = currentPosition;
        //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((float)(Time.timeAsDouble % myCurve.length)), transform.position.z);
    }
} 
 