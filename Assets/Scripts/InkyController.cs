using UnityEngine;
using System.Collections;

public class InkyController : GhostController {

	public float targetPositionOffset = 1.5f;

	private GameObject blinky;

	protected override void doOnStart() {
		blinky = GameObject.Find("Blinky");
	}
	
	protected override void doOnUpdate () {
		if (GameController.mode.Equals(GameController.GameMode.Chase)) {
			Vector3 pacmanDirection = new Vector3(
				pacman.transform.eulerAngles.x,
				pacman.transform.eulerAngles.y,
				pacman.transform.eulerAngles.z
			) / 360.0f;

			Vector3 pacmanPositionWithOffset = pacman.transform.position + (pacmanDirection * targetPositionOffset);
			Vector3 blinkyToPacman = pacman.transform.position - blinky.transform.position;

			target = pacmanPositionWithOffset + blinkyToPacman;
		} else {
			target = scatterCorner;
		}
	}
}
