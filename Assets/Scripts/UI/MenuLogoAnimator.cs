using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogoAnimator : MonoBehaviour
{
    public AnimationCurve yCurve;
    public AnimationCurve scaleCurve;
    public float ySpeed = 100.0f;
    public float scaleSpeed = 1.0f;
    public Vector3 finalScale;
    private float curveDeltaTime = 0.0f;
    private float graphScale = 0.0f;
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
        
        graphScale = scaleCurve.Evaluate(scaleSpeed*curveDeltaTime);
        transform.localScale=finalScale*graphScale;
        // Update the current position\
        transform.position = currentPosition;
        //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((float)(Time.timeAsDouble % myCurve.length)), transform.position.z);
    }
}
