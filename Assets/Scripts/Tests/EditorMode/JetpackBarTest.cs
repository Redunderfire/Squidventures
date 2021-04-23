using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JetpackBarTest
{
    private const int testingValue = 2;
    // A Test behaves as an ordinary method
    [Test]
    public void TestSetMaxFuel()
    {
        var jetpackBar = new JetpackBar();
        jetpackBar.setMaxFuel(testingValue);
        Assert.Equals(testingValue, jetpackBar.slider.maxValue);
    }

    [Test]
    public void TestSetFuel()
    {
        var jetpackBar = new JetpackBar();
        jetpackBar.setMaxFuel(testingValue+1);
        jetpackBar.setFuel(testingValue);
        Assert.Equals(testingValue, jetpackBar.slider.value);
    }
}
