﻿using UnityEngine;
using System.Collections;

public class PelletController : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	public void OnTriggerEnter(Collider collider) {
		if (collider.transform.name == "CardboardMain") {
			GameController.score++;

			Destroy(gameObject);
		}
	}
}
