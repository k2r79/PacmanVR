using UnityEngine;
using System.Collections;

public class ClydeController : GhostController {

	public float distanceThreshold = 6.0f;

	protected override void doOnStart() {

	}
	
	protected override void doOnUpdate () {
		if (GameController.mode.Equals(GameController.GameMode.Chase)) {
			float distanceToPacman = Vector3.Distance(transform.position, pacman.transform.position);

			if (distanceToPacman < distanceThreshold) {
				target = scatterCorner;
			} else {
				target = pacman.transform.position;
			}
		} else {
			target = scatterCorner;
		}
	}
}
