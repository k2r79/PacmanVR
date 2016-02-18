using UnityEngine;
using System.Collections;

public class BlinkyController : GhostController {

	protected override void doOnStart() {

	}
	
	protected override void doOnUpdate () {
		if (GameController.mode.Equals(GameController.GameMode.Chase)) {
			target = pacman.transform.position;
		} else {
			target = scatterCorner;
		}
	}
}
