using UnityEngine;
using System.Collections;

public class bPlayerController : MonoBehaviour {
	
	public float speed;
	public float jumpHeight;

    public float gravity = .1f;
    public float friction = .01f;

    private Vector3 _velocity;
    private Vector3 _pos;
//    private CharacterController _charController;

    private Rigidbody rb;
	private bool isFalling = false;
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        _velocity = new Vector3();
        _pos = gameObject.transform.position;
//        _charController = GetComponentInChildren<CharacterController>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);
        //speed *= Time.deltaTime;
        rb.AddForce(movement * speed);


        if (Input.GetButtonDown("Jump") && isFalling == false)
        {
            rb.velocity = new Vector2(this.rb.velocity.x, jumpHeight);
            //		    rb.velocity = new Vector3(0, jumpHeight, 0);
            //			Vector3 v = rb.velocity;
            //			v.y = jumpHeight;
        }
        isFalling = true;
    }

    void OnCollisionStay()
    {
        isFalling = false;
    }

    //void Update()
    //{
    //    float hInput = Input.GetAxis("Horizontal");
    //    _velocity.x += (hInput * speed);

    //    _velocity.x *= friction;

    //    Debug.Log(_velocity);

    //    Debug.Log(_charController.isGrounded);

    //    if (!_charController.isGrounded)
    //    {
    //        _velocity.y -= gravity;
    //    }

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        Debug.Log("jump");
    //        _velocity.y = jumpHeight;
    //    }

    //    _pos += (_velocity * Time.deltaTime);

    //    _charController.transform.position = _pos;
    //}
}

