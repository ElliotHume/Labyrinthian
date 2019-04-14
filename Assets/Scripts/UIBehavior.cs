using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour {

	public bool isNoGravLocked;
	public bool isBigBallLocked;
	public bool isPillLocked;
	public bool isFlipLocked;

	private GameObject cameraButton;
	private GameObject noGravButton;
	private GameObject bigBallButton;
	private GameObject pillButton;
	private GameObject flipButton;

	private bool isCameraMode;
	private bool isFlipped;
	private bool isNoGrav;
	private bool isBigBall;

	// Use this for initialization
	void Start () {

		cameraButton = GameObject.Find ("CameraButton");
		noGravButton = GameObject.Find ("NoGravButton");
		bigBallButton = GameObject.Find ("BigBallButton");
		pillButton = GameObject.Find ("PillButton");
		flipButton = GameObject.Find ("FlipButton");

		if (isNoGravLocked) {
			noGravButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[1].color = new Color32 (255, 255, 255, 120);
			noGravButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[2].color = new Color32 (255, 255, 255, 0);
		}
		if (isBigBallLocked) {
			bigBallButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[1].color = new Color32 (255, 255, 255, 120);
			bigBallButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[2].color = new Color32 (255, 255, 255, 0);
		}
		if (isPillLocked) {
			pillButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[1].color = new Color32 (255, 255, 255, 120);
			pillButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[2].color = new Color32 (255, 255, 255, 0);
		}
		if (isFlipLocked) {
			flipButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[1].color = new Color32 (255, 255, 255, 120);
			flipButton.GetComponentsInChildren<UnityEngine.UI.RawImage> ()[2].color = new Color32 (255, 255, 255, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleCamera(){
		if (!isCameraMode) {
			cameraButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (230, 75, 75, 255);
		} else {
			cameraButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (230, 75, 75, 120);
		}
		isCameraMode = !isCameraMode;
	}

	public void toggleNoGrav(){
		if (!isNoGrav) {
			noGravButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (100, 80, 255, 255);
		} else {
			noGravButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (100, 80, 255, 120);
		}
		isNoGrav = !isNoGrav;
	}

	public void toggleBigBall(){
		if (!isBigBall) {
			bigBallButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (230, 75, 75, 255);
		} else {
			bigBallButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (230, 75, 75, 120);
		}
		isBigBall = !isBigBall;
	}

	public void togglePill(){
		pillButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (230, 75, 75, 255);
	}

	public void toggleFlip(){
		if (!isFlipped) {
			flipButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (100, 80, 255, 255);
		} else {
			flipButton.GetComponent<UnityEngine.UI.RawImage> ().color = new Color32 (100, 80, 255, 120);
		}
		isFlipped = !isFlipped;
	}
}
