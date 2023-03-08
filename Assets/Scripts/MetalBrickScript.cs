using UnityEngine;
using System.Collections;

public class MetalBrickScript : MonoBehaviour {
	
	private LevelManager levelManager;
	
	public AudioClip blockDestroy;
	public AudioClip blockHit;
	
	public Sprite clean;
	public Sprite stageOne;
	public Sprite stageTwo;
	public Sprite stageThree;
	public int maxHits;
	public int timesHit;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (timesHit == maxHits) {
			Debug.Log ("Brick is Gone!");
			AudioSource.PlayClipAtPoint(blockDestroy, transform.position);
			levelManager.AllBricksGone();
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player Laser") {
			timesHit++;
			AudioSource.PlayClipAtPoint(blockHit, transform.position, 0.2f);
			LevelManager.score = LevelManager.score + 10;
			if (timesHit < maxHits / 4) {
				GetComponent<SpriteRenderer>().sprite = clean;
			}
			else if (timesHit < maxHits / 2) {
				GetComponent<SpriteRenderer>().sprite = stageOne;
			}
			else if (timesHit < (maxHits * 3 / 4)) {
				GetComponent<SpriteRenderer>().sprite = stageTwo;
			}
			else {
				GetComponent<SpriteRenderer>().sprite = stageThree;
			}
			GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
