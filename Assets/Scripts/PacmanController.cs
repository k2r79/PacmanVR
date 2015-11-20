using UnityEngine;
using System.Collections;

public class PacmanController : MonoBehaviour {

	public float speed = 0.1f;
	public int lifes = 3;
	public Vector3 startPosition = new Vector3 (-10.4f, 1.149f, -5.911f);

	private GameObject pacman;
	private CharacterController pacmanCharacter;
	private CardboardHead cardboardHead;
	private UnityEngine.UI.Text lifeHUD;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		pacmanCharacter = GetComponent<CharacterController> ();
		cardboardHead = GetComponentInChildren<CardboardHead> ();
		lifeHUD = GameObject.Find ("HUD Life").GetComponent<UnityEngine.UI.Text>();

		lifeHUD.text = "Test";

		SetStartPosition ();
		UpdateHUD ();
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
			CollidedWithGhost();
		}
	}

	void SetStartPosition () {
		transform.position = startPosition;
	}
	
	void CollidedWithGhost() {
		SetStartPosition ();
		
		if (--lifes < 0) {
			GameOver();
		}

		UpdateHUD ();
	}

	void UpdateHUD() {
		lifeHUD.text = lifes.ToString();
	}

	void GameOver() {
		Debug.Log ("Game Over !");
	}
}
