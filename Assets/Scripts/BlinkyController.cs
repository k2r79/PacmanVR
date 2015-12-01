using UnityEngine;
using System.Collections;

public class BlinkyController : MonoBehaviour {
	
	public Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		transform.position = startingPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
