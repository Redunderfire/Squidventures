using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectiveManagerTest
{
    private const int startingValue = 0;
    private GameObject managerObj;
    private GameObject circleObj;

   /* public class forceSlider : UnityEngine.UI.Slider {
    } */
    

    [SetUp]
    public void SetUp(){
        // instantiate objects
        managerObj = new GameObject();
        circleObj = new GameObject();

        // add components
        managerObj.AddComponent<ObjectiveManager>();
        circleObj.AddComponent<ObjectiveCircle>();
        circleObj.AddComponent<UnityEngine.UI.Slider>();
    }
    [Test]
    public void TestIncrementObjValue()
    {
        // get references
        var objManager = managerObj.GetComponent<ObjectiveManager>();
        var slider = circleObj.GetComponent<UnityEngine.UI.Slider>();
        var circle = circleObj.GetComponent<ObjectiveCircle>();

        // assign public objects
        circle.slider = slider;
        objManager.objectiveCircle = circle;

        // set values
        objManager.currentValue = startingValue;
        
        //action
        objManager.incrementObjValue();
        Assert.Greater(objManager.currentValue, startingValue);
    }
}
