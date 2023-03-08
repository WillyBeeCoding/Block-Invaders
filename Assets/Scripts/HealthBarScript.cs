using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public GameObject healthBar;
	private float xScale;
	private int trueHealth;
	private float healthRatio;

	// Use this for initialization
	void Start () {
		xScale = healthBar.transform.localScale.x;
		trueHealth = HealthManager.health;
	}
	
	// Update is called once per frame
	void Update () {
		healthRatio = (HealthManager.health) / 100f;
		print ("HEALTH RATIO: " + healthRatio);
		if (trueHealth != HealthManager.health) {
			changeBar();
			trueHealth = HealthManager.health;
		}
	}
	
	void changeBar () {
		healthBar.transform.localScale = new Vector3(healthRatio * xScale, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
