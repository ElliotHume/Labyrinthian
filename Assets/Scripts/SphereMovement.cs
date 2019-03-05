﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(pressUp)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (1, 0, 0);
			sphere.transform.Rotate(50.0f * Time.deltaTime, 0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(pressRight)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (0, -1, 0);
			sphere.transform.Rotate(0.0f, 50.0f * Time.deltaTime, 0.0f, Space.World);
		}
		if (Input.GetKey(pressDown)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (-1, 0, 0);
			sphere.transform.Rotate(-50.0f * Time.deltaTime, 0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(pressLeft)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (0, 1, 0);
			sphere.transform.Rotate(0.0f, -50.0f * Time.deltaTime, 0.0f, Space.World);
		}
		if (Input.GetKey(clockwise)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (0, 1, 0);
			sphere.transform.Rotate(0.0f, 0.0f, -50.0f * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(counterClockwise)) {
			//GetComponent<Transform> ().eulerAngles += new Vector3 (0, 1, 0);
			sphere.transform.Rotate(0.0f, 0.0f, 50.0f * Time.deltaTime, Space.World);
		}
	}
}
