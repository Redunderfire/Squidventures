using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerMoveTest
{
    private PlayerMove pMove;
    private GameObject jBar;

    // A Test behaves as an ordinary method
    [OneTimeSetUp]
    public void LoadScene(){
        SceneManager.LoadScene("Terrain");
    }

    [SetUp]
    public void SetUp(){
    }

    [UnityTest]
    public IEnumerator TestMove()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        Vector3 startLocation = GameObject.Find("FPSPlayer").GetComponent<Transform>().position;
        pMove.ReceiveInput(new Vector2(10, 0));
        yield return null;
        Assert.That(GameObject.Find("FPSPlayer").GetComponent<Transform>().position.x > startLocation.x);
    }

    [UnityTest]
    public IEnumerator TestMoveRight()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        Vector3 startLocation = GameObject.Find("FPSPlayer").GetComponent<Transform>().position;
        pMove.ReceiveInput(new Vector2(10, 0));
        yield return null;
        Assert.That(GameObject.Find("FPSPlayer").GetComponent<Transform>().position.x > startLocation.x);
    }

    [UnityTest]
    public IEnumerator TestMoveLeft()
    { 
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        Vector3 startLocation = GameObject.Find("FPSPlayer").GetComponent<Transform>().position;
        pMove.ReceiveInput(new Vector2(-10, 0));
        yield return null;
        Assert.That(GameObject.Find("FPSPlayer").GetComponent<Transform>().position.x < startLocation.x);
    }

    [UnityTest]
    public IEnumerator TestMoveForward()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        Vector3 startLocation = GameObject.Find("FPSPlayer").GetComponent<Transform>().position;
        pMove.ReceiveInput(new Vector2(0, 10));
        yield return null;
        Assert.That(GameObject.Find("FPSPlayer").GetComponent<Transform>().position.z > startLocation.z);
    }

    [UnityTest]
    public IEnumerator TestJump()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        Vector3 startLocation = GameObject.Find("FPSPlayer").GetComponent<Transform>().position;
        pMove.isGrounded = true;
        pMove.JumpEvent(true);
        yield return null;
        Assert.That(GameObject.Find("FPSPlayer").GetComponent<Transform>().position.y > startLocation.y);
    }
    
    [UnityTest]
    public IEnumerator TestBoost()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        float startFuel = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>().currentFuel;
        pMove.isGrounded = false;
        pMove.JumpEvent(true);
        yield return null;
        Assert.That(pMove.currentFuel < startFuel);
    }

    [UnityTest]
    public IEnumerator TestRegainFuel()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        pMove.currentFuel = 80f;
        pMove.isGrounded = true;
        yield return new WaitForSeconds(2);
        Assert.That(pMove.currentFuel > 80f);
    }

    [UnityTest]
    public IEnumerator TestSprint()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        float startSpeed = pMove.speed;
        pMove.SprintEvent(true);
        yield return null;
        Assert.That(pMove.speed > startSpeed);
    }

    [UnityTest]
    public IEnumerator TestWalk()
    {
        pMove = GameObject.Find("FPSPlayer").GetComponent<PlayerMove>();
        pMove.SprintEvent(true);
        yield return null;
        float startSpeed = pMove.speed;
        pMove.SprintEvent(false);
        yield return null;
        Assert.That(pMove.speed < startSpeed);
    }
}
