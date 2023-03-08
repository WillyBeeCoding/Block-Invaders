using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	public int powerUpIndex;
	public ReversePaddleScript twinPaddle;
	/* 
	0 - Paddle Plus
	1 - Extra Life
	2 - Sticky Shot
	3 - Twin Paddles
	4 - Superball
	5 - Fastball
	6 - Paddle Lift
	7 - Short Paddle
	*/
	private LevelManager levelManager;
	private HealthManager healthManager;
	private PaddleScript paddle;
	private BallScript ball;
	private Vector2 smallSize;
	private Vector2 largeSize;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		paddle = GameObject.FindObjectOfType<PaddleScript>();
		healthManager = GameObject.FindObjectOfType<HealthManager>();
		ball = GameObject.FindObjectOfType<BallScript>();
		smallSize = new Vector2(1f, 1f);
		largeSize = new Vector2(3f, 1f);
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (powerUpIndex == 0) {
			paddle.transform.localScale = largeSize;
		}
		else if (powerUpIndex == 1) {
			healthManager.addHeart();
		}
		else if (powerUpIndex == 2) {
			paddle.SetSticky();
		}
		else if (powerUpIndex == 3) {
			Instantiate(twinPaddle);
		}
		else if (powerUpIndex == 4) {
			Debug.Log("SUPERBALL");
		}
		else if (powerUpIndex == 5) {
			Debug.Log("FASTBALL");
		}
		else if (powerUpIndex == 6) {
			Debug.Log("PADDLELIFT");
		}
		else if (powerUpIndex == 7) {
			paddle.transform.localScale = smallSize;
		}
		Destroy(gameObject);
	}
}

