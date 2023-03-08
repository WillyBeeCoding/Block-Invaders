using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private HealthManager healthManager;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		healthManager = GameObject.FindObjectOfType<HealthManager>();
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		print ("Collision");
		if (col.gameObject.transform.name == "Ball") {
			BallScript.hasStarted = false;
			healthManager.removeHeart();
		}
	}
}
