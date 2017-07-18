using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
    public float speed = 30;

    private Vector2 originalVelocity;
    private Vector2 originalPosition;

    private Rigidbody2D rBod;


	// Use this for initialization
	void Start () {
        originalPosition = GetComponent<Rigidbody2D>().position;
        originalPosition = transform.position;
        originalVelocity = Vector2.right * speed;

        rBod = GetComponent<Rigidbody2D>();
        rBod.velocity = Vector2.right * speed;

	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string collideName = collision.gameObject.name;
        if (collideName.Contains("Player")) {
            handlePaddleHit(collision);
        }
        else if (collideName.Equals("Top")) {

        }
        else if (collideName.Equals("Bottom")) {

        }
        else if (collideName.Equals("LeftGoal")) {
            rBod.velocity = new Vector2(0, 0);
            reset();
        }
        else if (collideName.Equals("RightGoal")) {
            rBod.velocity = new Vector2(0, 0);
            reset();
        }
    }

    private void reset() {
        GetComponent<Rigidbody2D>().position = originalPosition;
        GetComponent<Rigidbody2D>().velocity = originalVelocity;
    }

    private void handlePaddleHit(Collision2D collision) {
        float y = ballHitPaddleWhere(transform.position, collision.transform.position, collision.collider.bounds.size.y);
        Vector2 dir = new Vector2();
        if (collision.gameObject.name.Equals("LeftPlayer")) {
            dir = new Vector2(1, y).normalized;
        }

        if (collision.gameObject.name.Equals("RightPlayer")) {
            dir = new Vector2(-1, y).normalized;
        }

        rBod.velocity = dir * speed;
    }

    private void handlePaddleHit(Collision collision) {
       
    }

    private float ballHitPaddleWhere(Vector2 ball, Vector2 paddle, float y) {
        return (ball.y - paddle.y) / y;
    }

}
