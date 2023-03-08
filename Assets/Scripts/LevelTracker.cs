using UnityEngine;
using System.Collections;

public class LevelTracker : MonoBehaviour {
	
	static LevelTracker instance = null;
	private int levelIndex;
	private int lastLevelIndex;
	// Use this for initialization
	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			levelIndex = 0;
			lastLevelIndex = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != levelIndex) {
			lastLevelIndex = levelIndex;
			levelIndex = Application.loadedLevel;
		}
	}
	
	public int getLevel () {
		return levelIndex;
	}
	
	public int getLastLevel () {
		return lastLevelIndex;
	}
}
