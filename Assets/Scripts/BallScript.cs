using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public AudioClip bounce;
	public AudioClip blockHit;
	
	private PaddleScript paddle;
	public static bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleScript>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Locks the ball to paddle until click.
			this.transform.position = paddleToBallVector + paddle.transform.position;
			if (Input.GetMouseButtonDown(0)) { 
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				hasStarted = true; //Exits Loop
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) { 
		Vector2 tweak = new Vector2(Random.Range(0f, 0.1f), Random.Range(0f, 0.1f));
		if (hasStarted) {
			GetComponent<Rigidbody2D>().velocity += tweak;
			if (col.gameObject.tag == "isBreakable") {
				AudioSource.PlayClipAtPoint(blockHit, transform.position, 0.2f);
			}
			else {
				AudioSource.PlayClipAtPoint(bounce, transform.position, 0.2f);
			}
		}
	}
}
