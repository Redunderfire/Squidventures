using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JetpackBarTest
{

    private const int testingValue = 2;
    private GameObject barObj;
    // A Test behaves as an ordinary method
    [SetUp]
    public void SetUp(){
        // instantiate and add components
        barObj = new GameObject("test");
        barObj.AddComponent<JetpackBar>();
        barObj.AddComponent<UnityEngine.UI.Slider>();

        // get references
        var objBar = barObj.GetComponent<JetpackBar>();
        var slider = barObj.GetComponent<UnityEngine.UI.Slider>();

        // set public objects
        objBar.slider = slider;
    }
    [Test]
    public void TestSetMaxFuel()
    {
        var objBar = barObj.GetComponent<JetpackBar>();
        var slider = barObj.GetComponent<UnityEngine.UI.Slider>();
        
        objBar.setMaxFuel(testingValue);
        Assert.That(testingValue == slider.maxValue);
    }

    [Test]
    public void TestSetObj()
    {
        var objBar = barObj.GetComponent<JetpackBar>();
        var slider = barObj.GetComponent<UnityEngine.UI.Slider>();
        
        objBar.setMaxFuel(testingValue+1);
        objBar.setFuel(testingValue);
        Assert.That(testingValue == slider.value);
    }
}
