using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectiveCircleTest
{
    private const int testingValue = 2;
    // A Test behaves as an ordinary method
    [Test]
    public void TestSetMaxObj()
    {
        var objCircle = new ObjectiveCircle();
        objCircle.setMaxObj(testingValue);
        Assert.Equals(testingValue, objCircle.slider.maxValue);
    }

    [Test]
    public void TestSetObj()
    {
        var objCircle = new ObjectiveCircle();
        objCircle.setMaxObj(testingValue+1);
        objCircle.setObj(testingValue);
        Assert.Equals(testingValue, objCircle.slider.value);
    }

}
