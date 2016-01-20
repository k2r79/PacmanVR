using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameMode { Scatter, Chase, Frightened };
	public float[] gameModeDuration = new float[] { 7.0f, 20.0f, 10.0f };
	public static GameMode mode;

	public static int score;
	public static int eatenPellets;

	private static GameMode previousGameMode;
	private static float gameModeTimer;
	
	void Start () {
		mode = GameMode.Scatter;
		previousGameMode = mode;

		score = 0;
		eatenPellets = 0;

		gameModeTimer = 0.0f;
	}

	void Update () {
		gameModeTimer += Time.deltaTime;

		if (gameModeTimer > gameModeDuration[(int) mode]) {
			gameModeTimer = 0.0f;

			if (mode.Equals(GameMode.Frightened)) {
				mode = previousGameMode;
			} else {
				previousGameMode = mode;
				mode = (GameMode) ((int) ++mode % 2);
			}
		}
	}

	public static void SwitchToFrightened() {
		if (!mode.Equals (GameMode.Frightened)) {
			previousGameMode = mode;
		}

		mode = GameMode.Frightened;
		gameModeTimer = 0.0f;
	}
}
