using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public Text text;
	public Text finalGameText;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		text.text = "SCORE: " + LevelManager.score;
		finalGameText.text = LevelManager.score.ToString();
	}
}
