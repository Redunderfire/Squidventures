using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectiveManagerTest
{
    private const int startingValue = 1;

    [Test]
    public void TestIncrementObjValue()
    {
        var objManager = new ObjectiveManager();
        objManager.currentValue = startingValue;
        objManager.incrementObjValue();
        Assert.Greater(objManager.currentValue, startingValue);
    }
}
