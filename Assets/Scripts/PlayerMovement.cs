using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //private Rigidbody pRdb;

    //Variablar
    private CharacterController cCont;
    private float speed = 6.0F;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;
    private float trunSpeed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
       // pRdb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        cCont = GetComponent<CharacterController>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
    }
    void Update () {


        if (cCont.isGrounded)
        {
            Movement();
        }
        if (!cCont.isGrounded)
        {
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
        }

        // Gravity och movement.
            moveDirection.y -= gravity * Time.deltaTime;
            cCont.Move(moveDirection * Time.deltaTime);
    }

    void Movement()
    {

        //Movment och Jump Kod
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * trunSpeed, 0 ));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
   
    }
    void OnCollisionEnter(Collision col)
    {
    
      
    }
}
