using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameMode { Scatter, Chase, Frightened };
	public float[] gameModeDuration = new float[] { 7.0f, 20.0f, 10.0f };
	public static GameMode mode;

	public static int score;

	private GameMode previousGameMode;
	private float gameModeTimer;
	
	void Start () {
		mode = GameMode.Scatter;
		previousGameMode = mode;

		score = 0;

		gameModeTimer = 0.0f;
	}

	void Update () {
		gameModeTimer += Time.deltaTime;

		if (gameModeTimer > gameModeDuration[(int) mode]) {
			gameModeTimer = 0.0f;

			previousGameMode = mode;
			if (mode != GameMode.Frightened) {
				mode = (GameMode) ((int) ++mode % 2);
			} else {
				mode = previousGameMode;
			}
		}
	}
}
