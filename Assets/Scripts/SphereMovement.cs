using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour {

	private float movementSpeed; 

	private MovementControl moveCtrl; 

	// Use this for initialization
	void Start () {
		moveCtrl = GameObject.Find("Movement Controller").GetComponent<MovementControl>();
		movementSpeed = 40.0f * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (moveCtrl.activeMovement == "sphere") {

			Vector3 rotation = gameObject.transform.rotation.eulerAngles;

			if (moveCtrl.moveUp) {
				gameObject.transform.Rotate(movementSpeed, 0.0f, 0.0f, Space.World);
			}

			if (moveCtrl.moveLeft) {
				gameObject.transform.Rotate(0.0f, movementSpeed, 0.0f, Space.World);
			}

			if (moveCtrl.moveDown) {
				gameObject.transform.Rotate(-movementSpeed, 0.0f, 0.0f, Space.World);
			}

			if (moveCtrl.moveRight) {
				gameObject.transform.Rotate(0.0f, -movementSpeed, 0.0f, Space.World);
			}

			if (moveCtrl.rotateClockwise) {
				gameObject.transform.Rotate(0.0f, 0.0f, -movementSpeed, Space.World);
			}

			if (moveCtrl.rotateCounterClockwise) {
				gameObject.transform.Rotate(0.0f, 0.0f, movementSpeed, Space.World);
			}
		}
	}

	public void invertSphereVert () {
		gameObject.transform.Rotate (new Vector3 (0, 0, 180), Space.World);
	}
}
