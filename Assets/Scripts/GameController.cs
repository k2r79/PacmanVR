using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameMode { Scatter, Chase, Frightened };
	public float[] gameModeDuration = new float[] { 7.0f, 20.0f, 10.0f };
	public static GameMode mode;

	public static int score;
	
	private float gameModeTimer;
	
	void Start () {
		mode = GameMode.Scatter;

		score = 0;

		gameModeTimer = 0.0f;
	}

	void Update () {
		gameModeTimer += Time.deltaTime;

		if (gameModeTimer > gameModeDuration[(int) mode]) {
			gameModeTimer = 0.0f;

			mode = (GameMode) ((int) ++mode % 2);
		}
	}
}
