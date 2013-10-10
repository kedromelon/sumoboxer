using UnityEngine;
using System.Collections;

public class redspawn : MonoBehaviour {
	
	public GameObject redBlueprint;
	
	GameObject newCube;
	
	// Use this for initialization
	void Start () {
		newCube = Instantiate (redBlueprint, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void Spawn(){
		newCube = Instantiate (redBlueprint, transform.position, Quaternion.identity) as GameObject;
		GameObject currentOtherGuy = GameObject.Find("bluecube(Clone)");
		currentOtherGuy.GetComponent<blueplayer>().FindEnemy(newCube);
	}

}

