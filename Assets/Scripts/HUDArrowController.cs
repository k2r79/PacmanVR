using UnityEngine;
using System.Collections;

public class HUDArrowController : MonoBehaviour {

	public GameObject targetGhost;

	private GameObject pacman;
	
	void Start () {
		pacman = GameObject.Find ("Pacman");
	}

	void Update () {
		if (Vector3.Distance (transform.position, pacman.transform.position) < 2.0f) {
			this.enabled = true;

			Vector3 pacmanVector = transform.position - pacman.transform.position;
			Vector3 ghostVector = targetGhost.transform.position - pacman.transform.position;
			Vector3 difference = pacmanVector - ghostVector;

			float angleWithTarget = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			Debug.Log(angleWithTarget);

			Vector3 eulerAngles = new Vector3 (0, 0, angleWithTarget);
			transform.localEulerAngles = eulerAngles;
		} else {
			this.enabled = false;
		}
	}
}
