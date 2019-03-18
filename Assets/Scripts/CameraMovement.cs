using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private float movementSpeed;

	private Transform sphere;
	private Vector3 spherePosition;
	private MovementControl moveCtrl; 
	private Quaternion startingRotation;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere").GetComponent<Transform>();
		spherePosition = sphere.position;
		startingRotation = gameObject.transform.rotation;
		startingPosition = gameObject.transform.position;
		moveCtrl = GameObject.Find("Movement Controller").GetComponent<MovementControl>();
		movementSpeed = 40.0f * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveCtrl.activeMovement == "camera") {
			
			if (moveCtrl.moveUp) {
				transform.RotateAround (spherePosition, Vector3.left, movementSpeed);
				//gameObject.transform.Translate(Vector3.up * movementSpeed);
			}
			if (moveCtrl.moveLeft) {
				transform.RotateAround (spherePosition, Vector3.up, movementSpeed);
			}
			if (moveCtrl.moveDown) {
				transform.RotateAround (spherePosition, Vector3.right, movementSpeed);
			}
			if (moveCtrl.moveRight) {
				transform.RotateAround (spherePosition, Vector3.down, movementSpeed);
			}

			gameObject.transform.LookAt(sphere);
		}
	}

	public void reset() {
		gameObject.transform.rotation = startingRotation;
		gameObject.transform.position = startingPosition;
	}
}
