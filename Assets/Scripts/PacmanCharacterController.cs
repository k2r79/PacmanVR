using UnityEngine;
using System.Collections;

public class PacmanCharacterController : MonoBehaviour {
	public Vector3 startPosition;

	public void OnPacmanDeath () {
		transform.position = startPosition;
	}
}
