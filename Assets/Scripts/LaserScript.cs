using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public int whichLaser;
	public AudioClip laser;
	public AudioClip enemyLaser;

	void Start () {
		if (whichLaser == 0) {
			AudioSource.PlayClipAtPoint(laser, transform.position, 0.2f);
		}
		else if (whichLaser == 1) {
			AudioSource.PlayClipAtPoint(enemyLaser, transform.position, 0.1f);
		}
	}
	
	void Update () {
		if (whichLaser == 0) {
			transform.Translate(new Vector3(0, 10f, 0) * Time.deltaTime);
		}
		else if (whichLaser == 1) {
			transform.Translate(new Vector3(0, -10f, 0) * Time.deltaTime);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy" && whichLaser == 0) {
			Destroy(col.gameObject);
			LevelManager.score = LevelManager.score + 50;
		}
		Destroy(gameObject);
	}
}
