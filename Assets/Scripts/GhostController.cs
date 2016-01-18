using UnityEngine;
using System.Collections;

public abstract class GhostController : PacmanCharacterController {
	
	public Vector3 target;
	public Vector3 scatterCorner;
	public Vector3 nextPosition;

	public int pelletsBeforeStart = 0;
	public float speed = 1.0f;
	public float frightenedSpeed = 0.85f;
	
	private Vector3[] offsetVectors = new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0), new Vector3(0, 0, 1) };
	public float intersectionOffset = 1.5f;

	private CharacterController characterController;

	protected GameObject pacman;
	protected GameObject previousIntersection;

	private MeshRenderer bodyRenderer;
	protected Material baseBodyMaterial;
	public Material frightenedBodyMaterial;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		characterController = GetComponent<CharacterController> ();

		bodyRenderer = transform.Find ("Body").GetComponent<MeshRenderer> ();
		baseBodyMaterial = bodyRenderer.material;

		target = new Vector3();
		transform.localPosition = startPosition;

		doOnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.eatenPellets >= pelletsBeforeStart) {
			Vector3 moveDirection = Vector3.Normalize(nextPosition - transform.position);

			transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);

			if (GameController.mode.Equals(GameController.GameMode.Frightened)) {
				Blink();

				characterController.Move(moveDirection * frightenedSpeed * Time.deltaTime);
			} else {
				bodyRenderer.material = baseBodyMaterial;

				characterController.Move(moveDirection * speed * Time.deltaTime);
			}
		}

		doOnUpdate ();
	}

	void Blink() {
		bodyRenderer.material = frightenedBodyMaterial;
	}

	abstract protected void doOnStart();
	abstract protected void doOnUpdate();

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.parent != null && collider.transform.parent.name == "Intersections") {
			IntersectionController intersection = collider.GetComponent<IntersectionController> ();
			nextPosition = NextPosition (intersection);
			previousIntersection = collider.gameObject;
		}
	}

	protected Vector3 NextPosition(IntersectionController intersection) {
		if (GameController.mode.Equals(GameController.GameMode.Frightened)) {
			System.Random random = new System.Random();
			int randomIntersectionIndex;
			GameObject randomIntersection = intersection.gameObject;

			do {
				randomIntersectionIndex = random.Next(0, intersection.IntersectionList ().Length);
				randomIntersection = intersection.IntersectionList ()[randomIntersectionIndex];
			} while (randomIntersection == null);


			return randomIntersection.transform.position;
		}

		float minDistance = float.MaxValue;
		GameObject nextGameObject = intersection.gameObject;

		GameObject[] intersections = intersection.IntersectionList ();
		System.Array.Reverse (intersections);
		for (int intersectionIndex = 0; intersectionIndex < intersections.Length; intersectionIndex++) {
			GameObject childIntersection = intersections [intersectionIndex];

			if (childIntersection != null && childIntersection != previousIntersection) {
				float childIntersectionDistance = Vector3.Distance (intersection.transform.position + offsetVectors [intersectionIndex] * intersectionOffset, target);
				if (childIntersectionDistance < minDistance) {
					minDistance = childIntersectionDistance;
					nextGameObject = childIntersection;
				}
			}
		}

		return nextGameObject.transform.position;
	}

	public new void OnPacmanDeath() {
		enabled = false;

		base.OnPacmanDeath ();

		enabled = true;
	}

	public void Eaten() {
		transform.position = startPosition;
	}
}
