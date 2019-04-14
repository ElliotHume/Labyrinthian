using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
	public static float[] scores = new float[SceneManager.sceneCountInBuildSettings];
	public static bool isPaused = false;

	public static void togglePause () {
		if (isPaused) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
		isPaused = !isPaused;
	}
	public static void loadLevel(int levelNum) {
		SceneManager.LoadScene (levelNum);
		Time.timeScale = 1;
		isPaused = false;
	}

	public static void nextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		Time.timeScale = 1;
		isPaused = false;
	}

	public static void resetLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
		isPaused = false;
	}

	public static bool recordScore (float timeScore) {
		int levelIndex = SceneManager.GetActiveScene ().buildIndex;
		if (scores[levelIndex] == 0.0f || timeScore < scores[levelIndex]) {
			scores[levelIndex] = timeScore;
			return true;
		}
		return false;
	}
}
