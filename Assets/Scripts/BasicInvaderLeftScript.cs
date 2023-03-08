using UnityEngine;
using System.Collections;

public class BasicInvaderLeftScript : MonoBehaviour {

	public LaserScript laser;

	// Use this for initialization
	void Start () {
		InvokeRepeating("FireLaser", 0, Random.Range (2f, 7f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(3f, 0, 0) * Time.deltaTime);
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "Player Laser") {
			print ("Enemy Destroyed!");
			Destroy(gameObject);
		}
		else if (col.gameObject.tag == "Border") {
			Destroy(gameObject);
		}
	}
	
	
	void FireLaser () {
		Instantiate(laser, new Vector3(this.transform.position.x, this.transform.position.y - 1f, -2f) , this.transform.rotation);
	}
}
