using UnityEngine;
using System.Collections;

public class cameraswitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			if(camera.orthographic == false){
				camera.orthographic = true;
			}else{
				camera.orthographic = false;
			}
		}
	}
}
