using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour {

	public string nextLevel;
	private bool isBig = false;
	private bool sphereAsParent = true;
	private GameObject sphere;

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
