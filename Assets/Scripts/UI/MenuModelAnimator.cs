using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuModelAnimator : MonoBehaviour
{
    public AnimationCurve myCurve;
    public float speed = 100.0f;
    private float curveDeltaTime = 0.0f;


    void Start(){
    }
    void Update()
    {
        // Get the current position
        Vector3 currentPosition = transform.position;
        //currentPosition.x += speed * Time.deltaTime;
        // Call evaluate on that time   
        curveDeltaTime+= Time.deltaTime;   
        currentPosition.y = speed * myCurve.Evaluate(curveDeltaTime);   
        // Update the current position\
        transform.position = currentPosition;
        //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((float)(Time.timeAsDouble % myCurve.length)), transform.position.z);
    }
} 
 