using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour
{

    // Variablar
    private Transform target;
    private Transform pivot;
    private Transform player;
    private float rotateSpeed = 3f;
    private float posY = 0;
    private float posX = 0;
    [SerializeField]
    private float speedY = 10f;
    [SerializeField]
    private float speedX = 10f;
    private bool closeFar = true;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        //transform.parent = target.transform;
        pivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
      

    }
    void Update()
    {
    
    }
    void LateUpdate()
    {
        
        //Hämtar x och y pos för spelaren och plusas på.
        posY += Input.GetAxis("Mouse Y") * Time.deltaTime * speedY;
        posX += Input.GetAxis("Mouse X") * Time.deltaTime * speedX;

        //Ändar posen på pivoten och roterar spelaren.
        Vector3 move = new Vector3(target.position.x, posY, target.position.z);
        target.position = move;
        player.Rotate(Vector3.up, posX);
        // Resetar x rotationen
        posX = 0;


        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    if (closeFar == true)
        //    {
        //        pivot.position = target.position - player.position;
        //        closeFar = false;
        //    }

        //}
        //if (closeFar == false)
        //{
        //    pivot.position += new Vector3(0, 0, -2);
        //    closeFar = true;
        //}


        // Vart kameran ska kolla
        this.transform.LookAt(target);
        //Vad kameran följer
        this.transform.position = pivot.position;
       

    }

}