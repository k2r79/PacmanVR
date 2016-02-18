using UnityEngine;
using System.Collections;

public class PelletController : MonoBehaviour {

	public void OnTriggerEnter(Collider collider) {
		if (collider.transform.name == "CardboardMain") {
			GameController.eatenPellets++;
			GameController.score += 10;

			Destroy(gameObject);
		}
	}
}
