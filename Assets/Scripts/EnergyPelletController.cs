using UnityEngine;
using System.Collections;

public class EnergyPelletController : PelletController {

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.name == "CardboardMain") {
			GameController.score++;

			Destroy(gameObject);
		}
	}
}
