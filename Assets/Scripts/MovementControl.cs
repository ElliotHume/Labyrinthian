using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

	public bool moveUp;
	public bool moveLeft;
	public bool moveDown;
	public bool moveRight;
	public bool rotateClockwise;
	public bool rotateCounterClockwise;

	public Mesh pillMesh;
	public Mesh sphereMesh;

	public string activeMovement = "sphere";
	public UnityEngine.UI.Text timer;

	private KeyCode pressUp = KeyCode.W;
	private KeyCode pressLeft = KeyCode.A;
	private KeyCode pressDown = KeyCode.S;
	private KeyCode pressRight = KeyCode.D;
	private KeyCode clockwise = KeyCode.Q;
	private KeyCode counterClockwise = KeyCode.E;

	private SphereMovement sphere;
	private BallBehavior ball;
	private CameraMovement camera;
	private UIBehavior uiControls;

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere").GetComponent<SphereMovement> ();
		ball = GameObject.Find ("Ball").GetComponent<BallBehavior> ();
		camera = GameObject.Find ("Main Camera").GetComponent<CameraMovement> ();
		uiControls = GameObject.Find ("ButtonsPanel").GetComponent<UIBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {

		float yAxis = Input.GetAxis ("Vertical");
		float zAxis = Input.GetAxis ("Horizontal");

		// Listen to inputs for movement commands and set movement flags
		moveUp = Input.GetKey (KeyCode.W) || yAxis == -1 && Input.GetKey (KeyCode.Z);
		moveLeft = Input.GetKey (KeyCode.A) || yAxis == 1 && !Input.GetKey (KeyCode.Z);
		moveDown = Input.GetKey (KeyCode.S) || yAxis == 1 && Input.GetKey (KeyCode.Z);
		moveRight = Input.GetKey (KeyCode.D) || yAxis == -1 && !Input.GetKey (KeyCode.Z);
		rotateClockwise = Input.GetKey (KeyCode.E)|| zAxis  == -1;
		rotateCounterClockwise = Input.GetKey (KeyCode.Q) || zAxis == 1;


		// Listen for button Inputs

		if (Input.GetKeyDown ("joystick button 0") || Input.GetKeyDown("c")) {
			if (activeMovement == "sphere") {
				activeMovement = "camera";
			} else {
				activeMovement = "sphere";
				camera.reset ();
			}
			uiControls.toggleCamera ();
		}

		if (Input.GetKeyDown ("joystick button 1") || Input.GetKeyUp ("joystick button 1") || Input.GetKeyDown("g")) {
			ball.toggleGravity ();
			uiControls.toggleNoGrav ();
		}

		if (Input.GetKeyDown ("joystick button 2") || Input.GetKeyDown("f")) {
			sphere.invertSphereVert ();
			uiControls.toggleFlip ();
		}

//		if (Input.GetKeyDown ("joystick button 5")) {
//			ball.toggleShereAsParent ();
//		}

		if (Input.GetKeyDown ("joystick button 4") || Input.GetKeyDown("b")) {
			ball.toggleSizeIncrease ();
			uiControls.toggleBigBall ();
		}

		if (Input.GetKeyDown ("joystick button 3") || Input.GetKeyDown("p")) {
			ball.changeMesh (pillMesh);
			uiControls.togglePill();
		}


	}
}
