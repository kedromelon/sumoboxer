using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x > 6){
			transform.localScale -= new Vector3(.001f, 0f, 0f);
		}else if(transform.localScale.x > 3){
			transform.localScale -= new Vector3(.002f, 0f, 0f);
		}else if(transform.localScale.x > 2){
			transform.localScale -= new Vector3(.004f, 0f, 0f);
		}else if(transform.localScale.x > 1){
			transform.localScale -= new Vector3(.008f, 0f, 0f);
		}else if(transform.localScale.x > 0){
			transform.localScale -= new Vector3(.016f, 0f, 0f);
		}
		if (transform.localScale.x < .1f){
			Destroy (gameObject);
			if(int.Parse(GameObject.Find("redtext").guiText.text) > int.Parse(GameObject.Find("bluetext").guiText.text) ){
				Application.LoadLevel("redwin");
			}else if(int.Parse(GameObject.Find("redtext").guiText.text) < int.Parse(GameObject.Find("bluetext").guiText.text) ){
				Application.LoadLevel("bluewin");
			}else{
				Application.LoadLevel("tie");
			}
		}
	}
}
