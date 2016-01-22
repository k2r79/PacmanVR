using UnityEngine;
using System.Collections;

public class HUDArrowController : MonoBehaviour {

	private static float thresholdDistance = 8.0f;

	public GameObject targetGhost;

	private GameObject pacman;
	private CanvasRenderer renderer;

	void Start () {
		pacman = GameObject.Find ("Pacman");
		renderer = GetComponent<CanvasRenderer> ();
	}

	void Update () {
		float distanceToTargetGhost = Vector3.Distance (transform.position, targetGhost.transform.position);
		if (distanceToTargetGhost < thresholdDistance) {
			renderer.SetAlpha(1);

			float scale = 1.0f - (distanceToTargetGhost / thresholdDistance * 0.2f);
			transform.localScale = new Vector3(scale, scale, scale);

			Vector3 pacmanVector = transform.position - pacman.transform.position;
			Vector3 ghostVector = targetGhost.transform.position - transform.position;

			pacmanVector.y = 0;
			ghostVector.y = 0;

			Vector3 sideVector = Vector3.Cross(pacmanVector, Vector3.up);
			// if positionIndicator > 0, then ghost is at the left of Pacman
			float positionIndicator = Vector3.Dot(ghostVector, sideVector);

			float angle = Vector3.Angle(pacmanVector, ghostVector);
			int angleSign = positionIndicator > 0.0f ? -1 : 1;
	
			Vector3 eulerAngles = new Vector3 (0, 0, angle * angleSign);
			transform.localEulerAngles = eulerAngles;
		} else {
			renderer.SetAlpha(0);
		}
	}
}
