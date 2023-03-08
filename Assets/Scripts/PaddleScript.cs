using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

	public float mousePosInBlocks;
	public LaserScript laser;
	private bool isSticky;
	private bool ballCollided;
	private BallScript ball;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		isSticky = false;
		ball = GameObject.FindObjectOfType<BallScript>();
		ballCollided = false;
	}
	
	// Update is called once per frame
	void Update () {
		mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x * 16 / Screen.width, 1, 15);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, 0.75f, -2f);
		this.transform.position = paddlePos;
		if (ballCollided) {
			ball.transform.position = paddleToBallVector + this.transform.position;
			if (Input.GetMouseButtonDown(0)) { 
				ballCollided = false; //Exits Loop
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			Instantiate(laser, new Vector3(this.transform.position.x, this.transform.position.y + 0.75f, -2f) , this.transform.rotation);
		}
	}
	
	public void SetSticky () {
		isSticky = true;
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy Laser") {
			HealthManager.health = HealthManager.health - 10;
		}
		else if (isSticky) {
			Debug.Log("HELLO!");
			paddleToBallVector = ball.transform.position - this.transform.position;
			ballCollided = true;
			isSticky = false;
		}
	}
}
