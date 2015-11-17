using UnityEngine;
using System.Collections;

public class Char1Controller : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity = 0;
    public bool isFalling = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                verticalVelocity = jumpSpeed;
            }
        }
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnCollisionStay()
    {
        isFalling = false;
    }
}
