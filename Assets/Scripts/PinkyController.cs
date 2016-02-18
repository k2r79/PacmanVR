using UnityEngine;
using System.Collections;

public class PinkyController : GhostController {

	public float targetPositionOffset = 3.0f;

	protected override void doOnStart() {

	}
	
	protected override void doOnUpdate () {
		if (GameController.mode.Equals(GameController.GameMode.Chase)) {
			Vector3 pacmanDirection = new Vector3(
				pacman.transform.eulerAngles.x,
				pacman.transform.eulerAngles.y,
				pacman.transform.eulerAngles.z
			) / 360.0f;

			target = pacman.transform.position + (pacmanDirection * targetPositionOffset);
		} else {
			target = scatterCorner;
		}
	}
}
