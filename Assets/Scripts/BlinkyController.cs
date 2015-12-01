using UnityEngine;
using System.Collections;

public class BlinkyController : GhostController {

	protected override void doOnStart() {

	}
	
	protected override void doOnUpdate () {
		target = pacman.transform.position;
	}
}
