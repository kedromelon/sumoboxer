using UnityEngine;
using System.Collections;

public class blueplayer : MonoBehaviour {
	
	public float speed = 20;
	public float jumpforce = 200;
	
	bool onGround;
	int jumpCount;
	
	public static GameObject other;
	public static GUIText othertext;
	
	GameObject spawner;
	
	void Start () {
		other = GameObject.Find("redcube(Clone)");
		othertext = GameObject.Find ("redtext").guiText;
		spawner = GameObject.Find("bluespawner");
		jumpCount = 2;
	}
	
	public void FindEnemy(GameObject guy) {
		other = guy;
	}
	
	void FixedUpdate () {
		
		Ray ray1 = new Ray(transform.position + new Vector3(transform.localScale.x*3/8, 0, 0), -transform.up);
		RaycastHit rayHit1 = new RaycastHit();
			
		Ray ray2 = new Ray(transform.position - new Vector3(0, transform.localScale.x*3/8, 0), -transform.up);
		RaycastHit rayHit2 = new RaycastHit();
		
		if (Physics.Raycast(ray1, out rayHit1, transform.localScale.y / 2) || 
		Physics.Raycast(ray2, out rayHit2, transform.localScale.y / 2)){ 
			jumpCount = 0;
			onGround = true;
		}else{
			onGround = false;	
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.AddRelativeForce(Vector3.left * speed);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			rigidbody.AddRelativeForce(Vector3.right * speed);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Jump();
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			rigidbody.AddRelativeForce(Vector3.down * speed * 3);
		}	
	}
	
	void Jump(){
		if (onGround){
			rigidbody.AddForce(Vector3.up * jumpforce); 
			onGround = false;
		}else if(jumpCount < 1){
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
			rigidbody.AddForce(Vector3.up * (jumpforce) * .9f);
			jumpCount++;
		}else if(jumpCount < 2){
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
			rigidbody.AddForce(Vector3.up * (jumpforce) * .7f);
			jumpCount++;
		}
		
	}
	
	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject == other){
			
			Ray rayLeftTop = new Ray(transform.position + new Vector3(0, transform.localScale.y*3/8, 0), -transform.right);
			RaycastHit rayHitLeftTop = new RaycastHit();
			
			Ray rayLeftBot = new Ray(transform.position - new Vector3(0, transform.localScale.y*3/8, 0), -transform.right);
			RaycastHit rayHitLeftBot = new RaycastHit();
			
			Ray rayRightTop = new Ray(transform.position + new Vector3(0, transform.localScale.y*3/8, 0), transform.right);
			RaycastHit rayHitRightTop = new RaycastHit();
			
			Ray rayRightBot = new Ray(transform.position - new Vector3(0, transform.localScale.y*3/8, 0), transform.right);
			RaycastHit rayHitRightBot = new RaycastHit();
			
			if(Physics.Raycast(rayLeftTop, out rayHitLeftTop, transform.localScale.x / 2) || 
				Physics.Raycast(rayRightTop, out rayHitRightTop, transform.localScale.x / 2) ||
				Physics.Raycast(rayLeftBot, out rayHitLeftBot, transform.localScale.x / 2) || 
				Physics.Raycast(rayRightBot, out rayHitRightBot, transform.localScale.x / 2)){
				if ( Mathf.Abs(rigidbody.velocity.x) > Mathf.Abs(other.rigidbody.velocity.x) ){
						
					other.rigidbody.velocity = Vector3.zero;
					other.rigidbody.AddForce(new Vector3(Mathf.Clamp(rigidbody.velocity.x * 6, -50f, 50f), 0f, 0f), ForceMode.Impulse);
					rigidbody.velocity = Vector3.zero;
						
				}
			}
		}
	}
	
	void OnTriggerEnter(){
		Destroy(gameObject);
		int deaths = System.Int32.Parse(othertext.text) + 1;
		othertext.text = deaths.ToString();
		spawner.GetComponent<bluespawn>().Spawn();

	}
	

}
