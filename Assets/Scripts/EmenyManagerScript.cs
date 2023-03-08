using UnityEngine;
using System.Collections;

public class EmenyManagerScript : MonoBehaviour {

	public BasicInvaderScript invader;
	public BasicInvaderLeftScript leftInvader;
	public BasicInvaderRightScript rightInvader;

	// Use this for initialization
	void Start () {
		InvokeRepeating("MakeLeftMinion", 1f, 3f);
		InvokeRepeating("MakeRightMinion", 2f, 3f);
	}
	
	void MakeLeftMinion () {
		Instantiate(leftInvader, new Vector3(this.transform.position.x + 1f, this.transform.position.y + 7f, -2f) , this.transform.rotation);
	}
	
	void MakeRightMinion () {
		Instantiate(rightInvader, new Vector3(this.transform.position.x + 15f, this.transform.position.y + 5f, -2f) , this.transform.rotation);
	}
}
