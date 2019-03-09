using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Finish") {
			Debug.Log ("WIN");
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.collider.gameObject.tag == "Sphere") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
