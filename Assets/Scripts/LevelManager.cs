using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
	public static string[] levels = new string[] {"TestScene","Level1","Level2"};
	public static float[] scores = new float[levels.Length];
	public static int currentLevel = 1;
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
		isPaused = false;
	}

	public static void nextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		isPaused = false;
	}

	public static void resetLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		isPaused = false;
	}

	public static void pauseGame() {
		currentLevel = SceneManager.GetActiveScene().buildIndex;
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
