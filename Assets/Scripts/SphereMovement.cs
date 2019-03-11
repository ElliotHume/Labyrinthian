using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour {

	public KeyCode pressUp;
	public KeyCode pressRight;
	public KeyCode pressDown;
	public KeyCode pressLeft;
	public KeyCode clockwise;
	public KeyCode counterClockwise;
	public GameObject sphere;
	public float movementSpeed;
	private float[] snapAngles;

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere");

		snapAngles = new float[]{ 0.000001f, 90.0f, 180.0f, 270.0f, 360.0f };

		movementSpeed = 40.0f * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (Input.GetKey("joystick button 0"));

		float yAxis = Input.GetAxis ("Vertical");
		float zAxis = Input.GetAxis ("Horizontal");
		//Debug.Log (yAxis);
		//float yAxis = 0;
		//float zAxis = 0;


		Vector3 rotation = sphere.transform.rotation.eulerAngles;
		//Debug.Log (rotation);

		if (Input.GetKey(pressUp) || yAxis == -1) {
			sphere.transform.Rotate(movementSpeed, 0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(pressRight)) {
			sphere.transform.Rotate(0.0f, movementSpeed, 0.0f, Space.World);
		}
		if (Input.GetKey(pressDown) || yAxis == 1) {
			sphere.transform.Rotate(-movementSpeed, 0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(pressLeft)) {
			sphere.transform.Rotate(0.0f, -movementSpeed, 0.0f, Space.World);
		}
		if (Input.GetKey(clockwise) || zAxis == 1) {
			sphere.transform.Rotate(0.0f, 0.0f, -movementSpeed, Space.World);
		}
		if (Input.GetKey(counterClockwise) || zAxis == -1) {
			sphere.transform.Rotate(0.0f, 0.0f, movementSpeed, Space.World);
		}


	}
}
