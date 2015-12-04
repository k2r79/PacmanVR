using UnityEngine;
using System.Collections;

public abstract class GhostController : MonoBehaviour {

	public Vector3 startingPosition;
	public Vector3 target;
	
	protected NavMeshAgent navMeshAgent;
	protected GameObject pacman;
	protected Vector3 nextPosition;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		navMeshAgent = GetComponent<NavMeshAgent> ();

		transform.position = startingPosition;

		doOnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		navMeshAgent.SetDestination (nextPosition);

		doOnUpdate ();
	}

	abstract protected void doOnStart();
	abstract protected void doOnUpdate();

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.parent != null 
		    && collider.transform.parent.name == "Intersections") {
			IntersectionController intersection = collider.GetComponent<IntersectionController>();

			nextPosition = ClosestIntersection(intersection).transform.position;
		}
	}

	protected GameObject ClosestIntersection(IntersectionController intersection) {
		float minDistance = float.MaxValue;
		GameObject bestChildIntersection = null;

		foreach (GameObject childIntersection in intersection.IntersectionList()) {
			if (childIntersection != null) {
				float childIntersectionDistance = Vector3.Distance (childIntersection.transform.position, target);
				if (childIntersectionDistance < minDistance) {
					minDistance = childIntersectionDistance;
					bestChildIntersection = childIntersection;
				}
			}
		}

		return bestChildIntersection;
	}
}
