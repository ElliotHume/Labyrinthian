using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour {

	public string nextLevel;
	public Mesh pillMesh;
	private GameObject sphere;
	private bool biggieboi = false;
	private bool sphereAsParent = true;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Finish") {
			Debug.Log ("WIN");
			SceneManager.LoadScene (nextLevel);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.collider.gameObject.tag == "Sphere") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere");
	}
	
	// Update is called once per frame
	void Update () {

		// Gravity button
		if (Input.GetKeyDown("joystick button 0")){
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
		}
		if (Input.GetKeyUp("joystick button 0")){
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
		}

		// 180 vertical swap
		if (Input.GetKeyDown("joystick button 1")){
			sphere.transform.Rotate (new Vector3 (0, 0, 180), Space.World);
		}

		// biggie boi
		if (Input.GetKeyDown("joystick button 3")){
			if (!biggieboi) {
				gameObject.transform.localPosition += new Vector3 (0, 0.05f, 0);
				gameObject.transform.localScale *= 3;
				biggieboi = true;
			} else {
				gameObject.transform.localScale /= 3;
				biggieboi = false;
			}

		}

		// remove ball from sphere parent transformations
		if (Input.GetKeyDown("joystick button 2")){
			if (sphereAsParent) {
				gameObject.transform.SetParent (gameObject.transform.parent.parent);
				sphereAsParent = false;
			} else {
				gameObject.transform.SetParent (sphere.transform);
				sphereAsParent = true;
			}
		}

		// goodluckKiddoYoureAPillNow
		if (Input.GetKeyDown ("joystick button 4")) {
			gameObject.GetComponent<MeshFilter> ().mesh = pillMesh;
		}

	}

}
