using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerLookTest
{
    private PlayerLook pLook;

    [OneTimeSetUp]
    public void LoadScene(){
        SceneManager.LoadScene("Terrain");
    }

    private static float WrapAngle(float angle)
    {
        angle%=360;
        if(angle >180)
            return angle - 360;

        return angle;
    }

    [UnityTest]
    public IEnumerator TestLookLeft()
    {
        var pTransform =  GameObject.Find("FPSPlayer").GetComponent<Transform>();
        pLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
        float startYRotation = WrapAngle(pTransform.eulerAngles.y);
        pLook.ReceiveInput(new Vector2(10,0));
        yield return new WaitForSeconds(2);
        Assert.Greater(WrapAngle(pTransform.eulerAngles.y), startYRotation);
    }

    [UnityTest]
    public IEnumerator TestLookRight()
    {
        var pTransform =  GameObject.Find("FPSPlayer").GetComponent<Transform>();
        pLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
        float startYRotation = WrapAngle(pTransform.eulerAngles.y);
        pLook.ReceiveInput(new Vector2(-10,0));
        yield return new WaitForSeconds(2);
        Assert.Less(WrapAngle(pTransform.eulerAngles.y), startYRotation);
    }

    [UnityTest]
  public IEnumerator TestLookDown()
    {
        // Use the Assert class to test conditions //down is up
        var pTransform =  GameObject.Find("FPSPlayer").GetComponent<Transform>();
        pLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
        float startXRotation = WrapAngle(pLook.GetComponent<Transform>().eulerAngles.x);
        pLook.ReceiveInput(new Vector2(0,10));
        yield return new WaitForSeconds(2);
        Assert.Less(WrapAngle(pLook.GetComponent<Transform>().eulerAngles.x), startXRotation);
    }
    
    [UnityTest]
    public IEnumerator TestLookUp()
    {
        // Use the Assert class to test conditions //down is up
        var pTransform =  GameObject.Find("FPSPlayer").GetComponent<Transform>();
        pLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
        float startXRotation = WrapAngle(pLook.GetComponent<Transform>().eulerAngles.x);
        pLook.ReceiveInput(new Vector2(0,-10));
        yield return new WaitForSeconds(2);
        Assert.Greater(WrapAngle(pLook.GetComponent<Transform>().eulerAngles.x), startXRotation);
    }
}
