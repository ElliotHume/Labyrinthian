using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuFunctions : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;

	void Update () {
		if ((Input.GetAxis ("Fire2") != 0 || Input.GetAxis ("Fire3") != 0) && buttonSelected == false) {
			if (selectedObject != null) {
				Debug.Log ("Ive been messing myself up");
				Debug.Log (Input.GetAxis ("Fire2")); 
				eventSystem.SetSelectedGameObject (selectedObject);
				buttonSelected = true;
			}
		}
	}
		
	private void OnDisable() {
		buttonSelected = false;
	}

	public void resume() {
		LevelManager.togglePause ();
	}

	public void selectLevel(int levelIndex) {
		LevelManager.loadLevel (levelIndex);
	}

	public void Quit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
