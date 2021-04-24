using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectiveCircleTest
{
    private const int testingValue = 2;
    private GameObject circleObj;
    // A Test behaves as an ordinary method
    [SetUp]
    public void SetUp(){
        // instantiate and add components
        circleObj = new GameObject("test");
        circleObj.AddComponent<ObjectiveCircle>();
        circleObj.AddComponent<UnityEngine.UI.Slider>();

        // get references
        var objCircle = circleObj.GetComponent<ObjectiveCircle>();
        var slider = circleObj.GetComponent<UnityEngine.UI.Slider>();

        // set public objects
        objCircle.slider = slider;
    }
    [Test]
    public void TestSetMaxObj()
    {
        var objCircle = circleObj.GetComponent<ObjectiveCircle>();
        var slider = circleObj.GetComponent<UnityEngine.UI.Slider>();
        
        objCircle.setMaxObj(testingValue);
        Assert.That(testingValue == slider.maxValue);
    }

    [Test]
    public void TestSetObj()
    {
        var objCircle = circleObj.GetComponent<ObjectiveCircle>();
        var slider = circleObj.GetComponent<UnityEngine.UI.Slider>();
        
        objCircle.setMaxObj(testingValue+1);
        objCircle.setObj(testingValue);
        Assert.That(testingValue == slider.value);
    }

}
