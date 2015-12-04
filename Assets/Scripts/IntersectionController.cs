using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntersectionController : MonoBehaviour {

	public GameObject upIntersection;
	public GameObject leftIntersection;
	public GameObject downIntersection;
	public GameObject rightIntersection;

	public GameObject[] IntersectionList() {
		return new GameObject[] { upIntersection, leftIntersection, downIntersection, rightIntersection };
	}
}
