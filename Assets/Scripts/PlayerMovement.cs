using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody pRdb;
    private CharacterController cCont;
    private bool grounded = false;
    private float speed = 6.0F;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        pRdb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        cCont = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {


        if (cCont.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Jump"))
            {   
                moveDirection.y = jumpSpeed;  
            }

        }
        if (!cCont.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * 6f, moveDirection.y, Input.GetAxis("Vertical") * 6f);

        }
            moveDirection.y -= gravity * Time.deltaTime;
        cCont.Move(moveDirection * Time.deltaTime);


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }   
      
    }
}
