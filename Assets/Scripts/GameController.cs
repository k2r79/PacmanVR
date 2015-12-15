using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameMode { Scatter, Chase };
	public static GameMode mode;
	
	private float scatterTime;
	private float chaseTime;
	
	void Start () {
		mode = GameMode.Scatter;

		scatterTime = 0.0f;
		chaseTime = 0.0f;
	}

	void Update () {
		if (mode.Equals(GameMode.Scatter)) {
			scatterTime += Time.deltaTime;

			if (scatterTime > 7.0f) {
				scatterTime = 0.0f;

				mode = GameMode.Chase;
			}
		} else {
			chaseTime += Time.deltaTime;

			if (chaseTime > 20.0f) {
				chaseTime = 0.0f;
				
				mode = GameMode.Scatter;
			}
		}
	}
}
