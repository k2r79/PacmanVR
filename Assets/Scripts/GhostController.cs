using UnityEngine;
using System.Collections;

public abstract class GhostController : MonoBehaviour {

	public Vector3 startingPosition;
	public Vector3 target;
	
	protected NavMeshAgent navMeshAgent;
	protected GameObject pacman;

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		navMeshAgent = GetComponent<NavMeshAgent> ();

		transform.position = startingPosition;

		doOnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		navMeshAgent.SetDestination (target);

		doOnUpdate ();
	}

	abstract protected void doOnStart();
	abstract protected void doOnUpdate();
}
