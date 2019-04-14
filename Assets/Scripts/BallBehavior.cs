using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class BallBehavior : MonoBehaviour {

	public string nextLevel;
	private bool isBig = false;
	private bool sphereAsParent = true;
	private GameObject sphere;
	public float timer = 0;

	public Text timerText;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Finish") {
			LevelManager.recordScore ( Convert.ToSingle(Math.Round((decimal)timer, 2)));
			LevelManager.nextLevel();
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
		timerText = GameObject.Find ("Timer").GetComponent<Text>();
		int levelIndex = SceneManager.GetActiveScene ().buildIndex;
		GameObject.Find ("HighScore").GetComponent<Text>().text = LevelManager.scores [levelIndex] > 0 ? "Top Score:" + LevelManager.scores [levelIndex] : "Top Score: --.--";
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelManager.isPaused) {
			timer += Time.deltaTime;
		}
		timerText.text = Convert.ToString (Math.Round (timer, 2));
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
}
