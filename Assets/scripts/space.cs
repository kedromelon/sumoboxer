using UnityEngine;
using System.Collections;

public class space : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.color = new Color( 228f/255f , 255f/255f, 133f/255f,(Mathf.Cos(Time.time * 4.5f)+1)/2);
		if (Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel("fight");
		}
		
	}
	
	
}
