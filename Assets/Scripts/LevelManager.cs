using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
	public static string[] levels = new string[] {"TestScene","Level1","Level2"};
	public static float[] scores = new float[levels.Length];
	public static int currentLevel = 0;

	public static void loadLevel(int levelNum) {
		SceneManager.LoadScene (levels [levelNum]);
		currentLevel = levelNum;
	}

	public static void resetLevel() {
		SceneManager.LoadScene (levels [currentLevel]);
	}

	public static bool recordScore (float timeScore) {
		Debug.Log (timeScore);
		if (scores[currentLevel] == 0.0f || timeScore < scores[currentLevel]) {
			scores[currentLevel] = timeScore;
			return true;
		}
		return false;
	}
}
