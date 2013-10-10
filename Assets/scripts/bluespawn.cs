using UnityEngine;
using System.Collections;

public class bluespawn : MonoBehaviour {
	
	public GameObject blueBlueprint;
	
	GameObject newCube;
	
	// Use this for initialization
	void Start () {
		newCube = Instantiate (blueBlueprint, transform.position, Quaternion.identity) as GameObject;
	}

	public void Spawn(){
		newCube = Instantiate (blueBlueprint, transform.position, Quaternion.identity) as GameObject;
		GameObject currentOtherGuy = GameObject.Find("redcube(Clone)");
		currentOtherGuy.GetComponent<redplayer>().FindEnemy(newCube);
	}

}
