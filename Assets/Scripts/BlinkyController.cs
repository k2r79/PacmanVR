using UnityEngine;
using System.Collections;

public class BlinkyController : GhostController {

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman");
		navMeshAgent = GetComponent<NavMeshAgent> ();
		
		transform.position = startingPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (navMeshAgent.isOnNavMesh);
		target = pacman.transform.position;

		navMeshAgent.SetDestination (target);
	}
}
