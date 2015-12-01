using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public Vector3 startingPosition;
	public Vector3 target;

	protected NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();

		transform.position = startingPosition;
		navMeshAgent.SetDestination (target);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
