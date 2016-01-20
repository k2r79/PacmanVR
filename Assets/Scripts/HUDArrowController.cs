using UnityEngine;
using System.Collections;

public class HUDArrowController : MonoBehaviour {

	public GameObject targetGhost;

	private GameObject pacman;
	

	void Start () {
		pacman = GameObject.Find ("Pacman");
	}

	void Update () {
		if (true || Vector3.Distance (transform.position, targetGhost.transform.position) < 3.0f) {
			this.enabled = true;

			Vector3 pacmanVector = transform.position - pacman.transform.position;
			Vector3 ghostVector = targetGhost.transform.position - transform.position;

			pacmanVector.y = 0;
			ghostVector.y = 0;

			Vector3 sideVector = Vector3.Cross(pacmanVector, Vector3.up);
			// if positionIndicator > 0, then ghost is at the left of Pacman
			float positionIndicator = Vector3.Dot(ghostVector, sideVector);

			float angle = Vector3.Angle(pacmanVector, ghostVector);
		
			Vector3 eulerAngles = new Vector3 (0, 0, angle + (positionIndicator > 0.0f ? 180.0f : 0.0f));
			transform.localEulerAngles = eulerAngles;
		} else {
			this.enabled = false;
		}
	}
}
