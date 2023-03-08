using UnityEngine;
using System.Collections;

public class ReversePaddleScript : MonoBehaviour {
	
	public float mousePosInBlocks;
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
		Vector3 paddlePos = new Vector3(16f - mousePosInBlocks, 0.75f, 0f);
		this.transform.position = paddlePos;
		if (ballCollided) {
			ball.transform.position = paddleToBallVector + this.transform.position;
			if (Input.GetMouseButtonDown(0)) { 
				ballCollided = false; //Exits Loop
			}
		}
	}
	
	public void SetSticky () {
		isSticky = true;
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (isSticky) {
			Debug.Log("HELLO!");
			paddleToBallVector = ball.transform.position - this.transform.position;
			ballCollided = true;
			isSticky = false;
		}
	}
}
