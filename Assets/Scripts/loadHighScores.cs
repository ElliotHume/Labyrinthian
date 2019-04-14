using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadHighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
			Debug.Log (LevelManager.scores.Length);
			Debug.Log (i);
			FindObject ("Level" + i).GetComponentsInChildren<Text>()[1].text = LevelManager.scores [i] > 0 ? "Top Score:" + LevelManager.scores [i] : "Top Score: --.--";
		}
	}

	public GameObject FindObject(string name)
	{
		Transform[] trs= gameObject.GetComponentsInChildren<Transform>(true);
		foreach(Transform t in trs){
			if(t.name == name){
				return t.gameObject;
			}
		}
		return null;
	}
}
