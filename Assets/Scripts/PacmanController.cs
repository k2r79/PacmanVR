using UnityEngine;
using System.Collections;

public class PacmanController : MonoBehaviour {

	public float speed = 0.1f;
	public int lifes = 3;

	private GameObject pacman;
	private CharacterController pacmanCharacter;
	private CardboardHead cardboardHead;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		pacmanCharacter = GetComponent<CharacterController> ();
		cardboardHead = GetComponentInChildren<CardboardHead> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 headRotation = new Vector3(pacman.transform.eulerAngles.x, cardboardHead.transform.eulerAngles.y + 90, pacman.transform.eulerAngles.z);
		pacman.transform.eulerAngles = headRotation;

		Vector3 moveDirection = new Vector3 (cardboardHead.Gaze.direction.x, 0, cardboardHead.Gaze.direction.z);
		pacmanCharacter.Move (moveDirection * speed);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.name == "Ghost") {

		}
	}
}
