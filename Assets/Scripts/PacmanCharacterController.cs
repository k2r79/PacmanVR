using UnityEngine;
using System.Collections;

public class PacmanCharacterController : MonoBehaviour {
	public Vector3 startPosition;

	protected AudioSource audioSource;

	public AudioClip movingSound;
	public float movingSoundVolume;

	public AudioClip deathSound;
	public float deathSoundVolume;

	public void OnPacmanDeath () {
		transform.position = startPosition;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.parent != null && collider.transform.parent.name == "Intersections") {
			GameObject nextPortal = null;
			Vector3 offset = Vector3.zero;

			if (collider.transform.name == "Portal Right") {
				nextPortal = GameObject.Find("Portal Left");
				offset.x += 1;
			}

			if (collider.transform.name == "Portal Left") {
				nextPortal = GameObject.Find("Portal Right");
				offset.x -= 1;
			}

			if (nextPortal != null) {
				Vector3 teleportPosition = nextPortal.transform.position;
				teleportPosition.y = transform.position.y;

				transform.position = teleportPosition + offset;
			}
		}
	}
}
