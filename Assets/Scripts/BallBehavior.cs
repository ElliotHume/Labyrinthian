using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;

public class BallBehavior : MonoBehaviour {

	public string nextLevel;
	private bool isBig = false;
	private bool sphereAsParent = true;
	private GameObject sphere;
	public Stopwatch timer = new Stopwatch();

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Finish") {
			timer.Stop ();
			LevelManager.recordScore ( Convert.ToSingle(Math.Round(timer.Elapsed.TotalSeconds, 2)));
			LevelManager.loadLevel(LevelManager.currentLevel + 1);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.collider.gameObject.tag == "Sphere") {
			LevelManager.resetLevel ();
		}
	}

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere");
		timer.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void changeMesh ( Mesh mesh ) {
		gameObject.GetComponent<MeshFilter> ().mesh = mesh;
	}

	public void toggleSizeIncrease () {
		if (!isBig) {
			gameObject.transform.localPosition += new Vector3 (0, 0.05f, 0);
			gameObject.transform.localScale *= 3;
		} else {
			gameObject.transform.localScale /= 3;
		}
		isBig = !isBig;
	}

	public void toggleGravity () {
		gameObject.GetComponent<Rigidbody> ().useGravity = !gameObject.GetComponent<Rigidbody> ().useGravity;
	}

	public void toggleShereAsParent () {
		if (sphereAsParent) {
			gameObject.transform.SetParent (gameObject.transform.parent.parent);
		} else {
			gameObject.transform.SetParent (sphere.transform);
		}
		sphereAsParent = !sphereAsParent;
	}

}
