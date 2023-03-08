using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private LevelTracker levelTracker;
	private int levelIndex;
	private int lastLevelIndex;
	private BrickScript bricks;
	public static int brickCount;
	public static int score = 0;
	
	void Start () {
		levelTracker = GameObject.FindObjectOfType<LevelTracker>();
		bricks = GameObject.FindObjectOfType<BrickScript>();
		brickCount = 0;
	}
	
	void Update () {
		levelIndex = levelTracker.getLevel();
		lastLevelIndex = levelTracker.getLastLevel();
		Debug.LogWarning(brickCount.ToString());
	}

	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quit Requested");
		Application.Quit(); 
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void AllBricksGone() {
		if (brickCount <= 0) {
			LoadNextLevel();
			BallScript.hasStarted = false;
		}
	}
	
	public void LoadRetry() {
		Application.LoadLevel(lastLevelIndex);
		score -= 3000;
	}
}
