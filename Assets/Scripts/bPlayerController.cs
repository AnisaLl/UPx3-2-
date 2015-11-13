using UnityEngine;
using System.Collections;

public class bPlayerController : MonoBehaviour {
	
	public float speed;
	public float jumpHeight;
	
	private Rigidbody rb;
	private bool isFalling = false;
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (0.0f , 0.0f, moveHorizontal);
		//speed *= Time.deltaTime;
		rb.AddForce (movement * speed);

		
		if (Input.GetButtonDown("Jump") && isFalling == false)
		{
			rb.velocity = new Vector2(this.rb.velocity.x, jumpHeight);
//		    rb.velocity = new Vector3(0, jumpHeight, 0);
//			Vector3 v = rb.velocity;
//			v.y = jumpHeight;
		}
		isFalling = true;
	}
	
	void OnCollisionStay ()
	{
		isFalling = false;
	}
}

