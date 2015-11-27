using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity = 0;
    float xPos;
    bool seen = false;


    // Use this for initialization
    void Start()
    {
        xPos = GetComponent<Transform>().localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //Vector3 pos = GetComponent<Transform>().localPosition;
        //pos.x = xPos;
        //GetComponent<Transform>().localPosition = pos;
        //moveDirection = new Vector3(Mathf.Cos(60) * Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Mathf.Sin(60) * Input.GetAxisRaw("Horizontal"));
        moveDirection = new Vector3(0, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                verticalVelocity = jumpSpeed;
            }
        }
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
        if (GetComponent<Renderer>().isVisible)
            seen = true;
        if (seen && GetComponent<Renderer>().isVisible == false)
        {
            Debug.Log("game over");
        }
    }

}
