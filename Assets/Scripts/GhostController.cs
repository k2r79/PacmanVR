using UnityEngine;
using System.Collections;

public abstract class GhostController : PacmanCharacterController {
	
	public Vector3 target;
	public Vector3 scatterCorner;
	public int scoreBeforeStart = 0;
	
	private Vector3[] offsetVectors = new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0), new Vector3(0, 0, 1) };
	public float intersectionOffset = 1.5f;
	
	protected NavMeshAgent navMeshAgent;
	protected GameObject pacman;
	protected Vector3 nextPosition;
	protected GameObject previousIntersection;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		navMeshAgent = GetComponent<NavMeshAgent> ();

		transform.localPosition = startPosition;

		doOnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.score >= scoreBeforeStart) {
			navMeshAgent.SetDestination (nextPosition);
		}

		doOnUpdate ();
	}

	abstract protected void doOnStart();
	abstract protected void doOnUpdate();

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.parent != null 
		    && collider.transform.parent.name == "Intersections") {
			IntersectionController intersection = collider.GetComponent<IntersectionController>();

			nextPosition = ClosestIntersection(intersection).transform.position;
			previousIntersection = collider.gameObject;
		}
	}

	protected GameObject ClosestIntersection(IntersectionController intersection) {
		float minDistance = float.MaxValue;
		GameObject bestChildIntersection = null;

		GameObject[] intersections = intersection.IntersectionList ();
		System.Array.Reverse (intersections);
		for (int intersectionIndex = 0; intersectionIndex < intersections.Length; intersectionIndex++) {
			GameObject childIntersection = intersections [intersectionIndex];

			if (childIntersection != null && childIntersection != previousIntersection) {
				float childIntersectionDistance = Vector3.Distance (intersection.transform.position + offsetVectors [intersectionIndex] * intersectionOffset, target);
				if (childIntersectionDistance < minDistance) {
					minDistance = childIntersectionDistance;
					bestChildIntersection = childIntersection;
				}
			}
		}

		return bestChildIntersection;
	}

	public new void OnPacmanDeath() {
		navMeshAgent.enabled = false;
		enabled = false;

		base.OnPacmanDeath ();

		enabled = true;
		navMeshAgent.enabled = true;
	}
}
