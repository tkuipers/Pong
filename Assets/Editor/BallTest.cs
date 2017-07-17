using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BallTest {
    private GameObject pong;

    [SetUp]
    public void Init() {
        pong = GameObject.Find("Pong");
    }
    [Test]
    public void BallHasCorrectName() {
        Assert.AreEqual("Pong", pong.name);
    }

    [Test]
    public void BallHasCorrectStartingPosition() {
        Assert.AreEqual(new Vector2(0, 0), pong.GetComponent<Rigidbody2D>().position);
    }

    [Test]
    public void BallHasCorrectStartingVelocity() {
        Assert.AreEqual(new Vector2(0, 0), pong.GetComponent<Rigidbody2D>().velocity);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator BallTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
