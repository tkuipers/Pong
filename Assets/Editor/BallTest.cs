using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BallTest {
    private GameObject pong;
    private BallBehaviour b;

    [SetUp]
    public void Init() {
        pong = GameObject.Find("Pong");
        pong.AddComponent(typeof(BallBehaviour);
        
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

    [Test]
    public void BallGetsResetUponHittingGoal() {
        Collision2D col = new Collision2D();
        pong.GetComponent<Rigidbody2D>().position = new Vector2(2, 2);
        b.OnCollisionEnter2D(col);
        Assert.AreEqual(new Vector2(0, 0), pong.GetComponent<Rigidbody2D>().position);
    }
}
