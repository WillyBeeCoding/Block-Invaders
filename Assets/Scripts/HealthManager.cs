using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public static int health = 100;
	public HeartScript heart;
	
	private HeartScript[] hearts = new HeartScript[10];
	private int numOfHearts;
	private float heartDis;
	private Canvas canvas;
	private LevelManager levelManager;

	void Start () {
		numOfHearts = 0;
		heartDis = 30f;
		canvas = GameObject.FindObjectOfType<Canvas>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		addHeart(); addHeart(); addHeart();
	}
	
	void Update () {
		print (numOfHearts + " " + health);
		if (health <= 0) {
			removeHeart();
			health = 100;
		}
	}
	
	public void addHeart () {
		if (numOfHearts < 10) {
			hearts[numOfHearts] = (HeartScript)Instantiate(heart);
			hearts[numOfHearts].transform.SetParent(canvas.transform);
			hearts[numOfHearts].transform.position = new Vector3(heart.transform.position.x + ((numOfHearts) * 30f), heart.transform.position.y, -3f);
			numOfHearts++;
		}
		else {
			print ("MAX HEARTS REACHED");
		}
	}
	
	public void removeHeart () {
		if (numOfHearts > 0) {
			Destroy(hearts[numOfHearts - 1].gameObject);
			numOfHearts--;
			print (numOfHearts);
		}
		else {
			print ("GAME OVER");
			levelManager.LoadLevel("Lose");
		}
	}
}
