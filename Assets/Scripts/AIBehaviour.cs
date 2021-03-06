﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour {
    public float speed = 30;
    public float wiggleRoom = 0.0f;
    public BallBehaviour pong;
    void FixedUpdate() {
        if (pong != null) {
            Vector2 pongPos = pong.GetComponent<Rigidbody2D>().position;
            float paddleDir = getDirection(GetComponent<Rigidbody2D>().position, pongPos);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, paddleDir) * speed;
        }
    }

    private float getDirection(Vector2 myVec, Vector2 pongVec) {
        if(pongVec.y - myVec.y > wiggleRoom) {
            return 1;
        }
        else if (pongVec.y - myVec.y < -wiggleRoom) {
            return -1;
        }
        else {
            return 0;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
