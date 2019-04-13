using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
	public static string[] levels = new string[] {"TestScene","Level1","Level2"};
	public static float[] scores = new float[levels.Length];
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
		Debug.Log (timeScore);
		if (scores[SceneManager.GetActiveScene().buildIndex] == 0.0f || timeScore < scores[SceneManager.GetActiveScene().buildIndex]) {
			scores[SceneManager.GetActiveScene().buildIndex] = timeScore;
			return true;
		}
		return false;
	}
}
