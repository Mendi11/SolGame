using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Variablar
    public float mSpeed = 10;
    [SerializeField]
    private Transform mCanvas;
    [SerializeField]
    private Rigidbody mFireball;
    private Transform mPivot;
    private Transform mTarget;
    private Rigidbody mRgb;
    private int mGorund = 0;
   

    // Use this for initialization
    void Awake()
    {
        mRgb = GetComponent<Rigidbody>();
        mPivot = GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<Transform>();
        mTarget = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<Transform>();
        
    }

    void Start ()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (mFireball == null)
        //            return; 

    }

    void Update () {

        CursorHide();
        print(mGorund);
    }
    void LateUpdate()
    {
        // Movment.
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * mSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * mSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && mGorund > 0)
        {
            //Hoppar upp med force.
            mRgb.AddForce(Vector3.up * 200f);
        }
       
        if (Input.GetKey(KeyCode.Mouse1))
        {                     
            //Canvas ska vara ture om man håller höger mus knapp
            mCanvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastB();
            }
        }
        else
        {
            //Canvas ska vara false om man inte håller höger mus knapp
            mCanvas.gameObject.SetActive(false); 
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            mGorund += 1;
        }        
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mGorund -= 1;
        }

    }
    void Bullet(float speed, RaycastHit hit)
    {

        //Raycast hittar vad den kolliderar med hämtar positionen den kolliderar med.
        //Skjuter mot positionen. Skapar 
        Vector3 shootDirection = hit.point - transform.position;
        Rigidbody bulletClone = (Rigidbody)Instantiate(mFireball, transform.position, transform.rotation);
        Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GetComponent<Collider>());
        bulletClone.velocity = shootDirection * speed;

    }
    void CursorHide()
    {
        // Gömmer eller visar musen och låser den i skärm rutan.
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
        }


    }
    void RaycastB()
    {
        // Skapar en raycast som kollar vilken direction raycasten ska träffa.
        RaycastHit hit;
        Vector3 direction = mTarget.position - mPivot.position;
        Ray rayLaser = new Ray(mPivot.position, direction);
        Debug.DrawRay(mPivot.position, direction * 1000);
        if (Physics.Raycast(rayLaser, out hit, 1000))
        {
            if (hit.collider.tag == "Ground")
            {
                Bullet(5, hit);
            }
        }

    }
}
