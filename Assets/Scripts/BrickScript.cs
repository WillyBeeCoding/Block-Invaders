using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	
	private LevelManager levelManager;
	public Sprite red;
	public Sprite orange;
	public Sprite yellow;
	public Sprite green;
	public Sprite cyan;
	public Sprite blue;
	public Sprite purple;
	public int maxHits;
	public int timesHit;
	
	// Use this for initialization
	void Start () {
		bool isBreakable = (this.tag == "isBreakable");
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		LevelManager.brickCount++;
	}
	
	// Update is called once per frame
	void Update () {
		if (timesHit == maxHits) {
			Debug.Log ("Brick is Gone!");
			LevelManager.brickCount--;
			levelManager.AllBricksGone();
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.gameObject.name == "Ball") {
			timesHit++;
			LevelManager.score = LevelManager.score + 100;
			if (maxHits - timesHit == 1) {
				GetComponent<SpriteRenderer>().sprite = red;
			}
			else if (maxHits - timesHit == 2) {
				GetComponent<SpriteRenderer>().sprite = orange;
			}
			else if (maxHits - timesHit == 3) {
				GetComponent<SpriteRenderer>().sprite = yellow;
			}
			else if (maxHits - timesHit == 4) {
				GetComponent<SpriteRenderer>().sprite = green;
			}
			else if (maxHits - timesHit == 5) {
				GetComponent<SpriteRenderer>().sprite = cyan;
			}
			else if (maxHits - timesHit == 6) {
				GetComponent<SpriteRenderer>().sprite = blue;
			}
			else if (maxHits - timesHit == 7) {
				GetComponent<SpriteRenderer>().sprite = purple;
			}
		}
	}
}
