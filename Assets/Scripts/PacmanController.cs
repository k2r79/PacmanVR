using UnityEngine;
using System.Collections;

public class PacmanController : PacmanCharacterController {

	public float speed = 0.1f;
	public int lifes = 3;

	private GameObject pacman;
	private CharacterController pacmanCharacter;
	private CardboardHead cardboardHead;
	private UnityEngine.UI.Text lifeHUD;
	private UnityEngine.UI.Text scoreHUD;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		pacmanCharacter = GetComponent<CharacterController> ();
		cardboardHead = GetComponentInChildren<CardboardHead> ();
		lifeHUD = GameObject.Find ("HUD Life").GetComponent<UnityEngine.UI.Text>();
		scoreHUD = GameObject.Find ("HUD Score").GetComponent<UnityEngine.UI.Text>();

		startPosition = new Vector3 (-10.4f, 1.149f, -5.911f);
		transform.localPosition = startPosition;

		UpdateHUD ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 headRotation = new Vector3(pacman.transform.eulerAngles.x, cardboardHead.transform.eulerAngles.y + 90, pacman.transform.eulerAngles.z);
		pacman.transform.eulerAngles = headRotation;

		Vector3 moveDirection = new Vector3 (cardboardHead.Gaze.direction.x, 0, cardboardHead.Gaze.direction.z);
		pacmanCharacter.Move (moveDirection * speed);

		UpdateHUD ();
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.transform.parent.name == "Ghosts") {
			CollidedWithGhost();
		}
	}


	void CollidedWithGhost() {
		transform.parent.BroadcastMessage("OnPacmanDeath");

		if (--lifes < 0) {

		}
	}

	void UpdateHUD() {
		lifeHUD.text = lifes.ToString();
		scoreHUD.text = GameController.score.ToString ();
	}
}
